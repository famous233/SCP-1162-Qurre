using System.Collections.Generic;
using System.ComponentModel;
using System;
using MEC;
using Qurre;

namespace SCP1162
{
    public class Config
    {
        public static bool IsEnabled;
        public static bool UseHints;
        public static bool CanSpawnCorpses;
        public static string ItemDropMessage;
        public static ushort ItemDropMessageDuration;
        public static List<ItemType> Chances;
        public static List<ItemType> ParseItemSettings(string types)
        {
            string[] list = types.Split(',');
            List<ItemType> items = new List<ItemType>();
            foreach (string s in list)
            {
                try
                {
                    items.Add((ItemType)Enum.Parse(typeof(ItemType), s));
                }
                catch (Exception)
                {
                    Log.Error($"Failed to parse ItemType: {s}");
                }
            }

            return items;
        }
        public static void Reload()
        {
            Config.IsEnabled = Plugin.Config.GetBool("IsEnabled", true);
            Config.UseHints = Plugin.Config.GetBool("UseHints", true);
            Config.CanSpawnCorpses = Plugin.Config.GetBool("CanSpawnCorpses", true);
            Config.ItemDropMessage = Plugin.Config.GetString("ItemDropMessage", "<i>你尝试通过 <color=yellow>SCP-1162</color> 来获取另一个物品...</i>");
            Config.ItemDropMessageDuration = Plugin.Config.GetUShort("ItemDropMessageDuration", 5);
            Config.Chances = ParseItemSettings(Plugin.Config.GetString("LuckyItems", "KeycardO5,SCP500,MicroHID,KeycardNTFCommander,KeycardContainmentEngineer,SCP268,GunCOM15,GrenadeFrag,SCP207,Adrenaline,GunUSP,KeycardFacilityManager,Medkit,KeycardNTFLieutenant,KeycardSeniorGuard,Disarmer,KeycardZoneManager,KeycardScientistMajor,KeycardGuard,Radio,Ammo556,Ammo762,Ammo9mm,GrenadeFlash,WeaponManagerTablet,KeycardScientist,KeycardJanitor,Coin,Flashlight"));
            if (Chances.Count == 0)
                Log.Warn("No items were parsed from the config.");
        }
    }
}
