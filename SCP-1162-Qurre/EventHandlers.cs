using MEC;
using Mirror;
using Qurre;
using Qurre.API;
using Qurre.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SCP1162
{
    public class EventHandlers
    {
        public static Plugin Plugin;
        public EventHandlers(Plugin plugin) => Plugin = plugin;

        internal void OnItemDropped(DropItemEvent ev)
        {
            if (Vector3.Distance(ev.Player.Position, Map.GetRandomSpawnPoint(RoleType.Scp173)) <= 8.2f)
            {
                if (Config.UseHints)
                    ev.Player.ShowHint(Config.ItemDropMessage, Config.ItemDropMessageDuration);
                else
                {
                    ev.Player.ClearBroadcasts();
                    ev.Player.Broadcast(Config.ItemDropMessageDuration, Config.ItemDropMessage);
                }
                if (!Config.CanSpawnCorpses)
                {
                    ev.Pickup.itemId = Config.Chances[Random.Range(0, Config.Chances.Count)];
                    return;
                }
                int r = Random.Range(0, 14);
                if (r <= 13)
                    ev.Pickup.itemId = Config.Chances[Random.Range(0, Config.Chances.Count)];
                else
                {
                    ev.Pickup.itemId = ItemType.None;
                    int roleid = Random.Range(0, 12);
                    switch (roleid)
                    {
                        case 2:
                            roleid = 16;
                            break;
                        case 7:
                            roleid = 17;
                            break;
                        case 14:
                            roleid = 11;
                            break;
                    }
                    Map.SpawnRagdoll((RoleType)roleid, "早上好", ev.Player.Position + Vector3.up * 5f, new Quaternion(0, 0, 0, 0), "早上好", "早上好", 666);
                }
            }
        }
    }
}
