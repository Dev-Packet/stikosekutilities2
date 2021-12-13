using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;

namespace stikosekutilities2
{
    [BepInPlugin("devpacket.stikosekutilities2", "stikosekutilities2", "0.0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin stikosekutilities2 is loaded!");
        }
    }
}
