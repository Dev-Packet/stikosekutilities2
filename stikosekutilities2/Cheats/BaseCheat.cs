using Newtonsoft.Json;
using stikosekutilities2.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace stikosekutilities2.Cheats
{
    public class BaseCheat : LayoutHelpers
    {
        public BaseCheat(string name, WindowID windowID) : this(false, name, windowID)
        {
        }

        public BaseCheat(bool activated, string name, WindowID windowID)
        {
            Activated = activated;
            Name = name;
            WindowID = windowID;
        }

        [JsonIgnore]
        public static List<BaseCheat> Cheats { get; private set; }

        public bool Activated { get; protected set; }
        public string Name { get; protected set; }
        public WindowID WindowID { get; protected set; }

        public virtual void Update() { }
        public virtual void OnGUI() { }
        protected virtual void RenderElements() { }

        public void InitRender()
        {
            var window = GUIRenderer.GetWindow(WindowID);

            window.DrawWindowEvent += RenderElements;
        }

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
