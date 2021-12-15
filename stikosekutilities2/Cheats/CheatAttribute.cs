using stikosekutilities2.Utils;
using System;
using System.Linq;
using System.Reflection;

namespace stikosekutilities2.Cheats
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CheatAttribute : Attribute
    {

        public static BaseCheat[] GetAllCheats()
        {
            return 
                // Get Executing Assembly
                Assembly.GetExecutingAssembly().
                // Get all types
                GetTypes().
                // Search for Cheats
                Where(t => t.IsCheat()).
                // Create Instance of all Cheats
                Select(t => (BaseCheat)Activator.CreateInstance(t)).
                // Convert to Array
                ToArray();
        }

    }
}
