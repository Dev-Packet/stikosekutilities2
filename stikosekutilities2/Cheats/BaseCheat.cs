using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace stikosekutilities2.Cheats
{
    public class BaseCheat
    {
        [JsonIgnore]
        public static List<BaseCheat> Cheats { get; private set; }

        public bool Activated { get; protected set; }
        public string Name { get; protected set; }

        public virtual void Update() { }
        public virtual void OnGUI() { }

        public static void ExecuteForAllModules(Action<BaseCheat> action)
        {
            if(Cheats == null)
            {
                Cheats = CheatAttribute.GetAllCheats().ToList();
            }

            Cheats.ForEach(cheat =>
            {
                try
                {
                    action(cheat);
                } catch(Exception ex)
                {
                    Plugin.Log.LogError($"Error while executing Cheat \"{cheat.Name}\": {ex}");
                }
            });
        }

    }
}
