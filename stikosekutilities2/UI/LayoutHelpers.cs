using System.Text;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public class LayoutHelpers
    {
        public static string ElementHex = "#23a86d";
        public static Color elec = Color.red;
        public static string MakeEnable(string text, bool state, bool color = true)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(text).Append(" (");

            if (color)
                builder.Append(state ? "<color=green>ON" : "<color=red>OFF").Append("</color>");
            else
                builder.Append(state ? "ON" : "OFF");

            builder.Append(")");

            return builder.ToString();
        }

        public static bool Toggle(string text, bool toggled)
        {
            if (GUILayout.Button(MakeEnable(text, toggled)))
            {

                   
                toggled = !toggled;
            }

            return toggled;
        }

        public static bool Button(string text)
        {
            return GUILayout.Button(text);
        }

        public static float Slider(float minValue, float maxValue, float value)
        {
            return GUILayout.HorizontalSlider(value, minValue, maxValue);
        }

        public static void Label(string text)
        {
            GUILayout.Label(text);
        }

    }
}
