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
            GUIContent content = new(MakeEnable(text, toggled));

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button, GUILayout.Height(40));
         

            if (GUI.Button(buttonRect, content))
            {
               

                toggled = !toggled;
            }

            if (ColorUtility.TryParseHtmlString(ElementHex, out elec))
            {
                Utils.DrawingUtil.DrawColor(elec, buttonRect);
                Utils.DrawingUtil.DrawText(text, new Rect(buttonRect.x + 5, buttonRect.y + 5, buttonRect.width - 10, buttonRect.height - 10), 12, Color.white);

                
                
                Utils.DrawingUtil.DrawColor(WindowManager.border, new Rect(buttonRect.width - 30, buttonRect.y + 5, 30, 30));
               
            }

            if (toggled)
            {
                Utils.DrawingUtil.DrawColor(elec, new Rect(buttonRect.width - 25, buttonRect.y + 10, 20, 20));
            }
            



            return toggled;
        }

        public static bool Button(string text)
        {
            GUIContent content = new(text);

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button);

            return GUI.Button(buttonRect, content);
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
