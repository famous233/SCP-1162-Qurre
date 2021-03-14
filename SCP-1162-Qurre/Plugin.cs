using System;
using Qurre.Events;
using Qurre.Events.modules;

namespace SCP1162
{
    public class Plugin : Qurre.Plugin
    {
        #region override
        public override string Name => "SCP1162";
        public override string Developer => "xRoier / L.S.";
        public override void Reload() => Config.Reload();
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        #endregion 
        #region Events

        internal EventHandlers EventHandlers;
        public override Version Version { get; } = new Version(1, 0, 0);
        public override System.Version NeededQurreVersion => new System.Version(1, 1, 5);
        public void RegisterEvents()
        {
            Config.Reload();
            EventHandlers = new EventHandlers(this);
            Player.DropItem += EventHandlers.OnItemDropped;
        }
        public void UnregisterEvents()
        {
            Player.DropItem -= EventHandlers.OnItemDropped;
            EventHandlers = null;
        }
        #endregion
    }
}
