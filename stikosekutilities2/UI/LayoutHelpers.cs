using stikosekutilities2.Utils;
using System.Text;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public class LayoutHelpers
    {
        public static string ElementHex = "#23a86d";
        public static Color elec = Color.red;

        private static GUIStyle
            horizontalSlider,
            horizontalSliderThumb;

        public static string MakeEnable(string text, bool state, bool color = true)
        {
            StringBuilder builder = new();
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

            ColorUtility.TryParseHtmlString(ElementHex, out elec);
            
            DrawingUtil.DrawColor(elec, buttonRect);
            DrawingUtil.DrawText(text, new Rect(buttonRect.x + 5, buttonRect.y + 5, buttonRect.width - 10, buttonRect.height - 10), 12, Color.white);

               
            DrawingUtil.DrawColor(WindowManager.border, new Rect(buttonRect.width - 30, buttonRect.y + 5, 30, 30));
            

            if (toggled)
            {
                DrawingUtil.DrawColor(elec, new Rect(buttonRect.width - 25, buttonRect.y + 10, 20, 20));
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
            if (horizontalSlider == null)
            {
                horizontalSlider = GUI.skin.horizontalSlider;
                horizontalSliderThumb = GUI.skin.horizontalSliderThumb;

                ColorUtility.TryParseHtmlString("#2d2f31", out Color sliderBackgroundColor);
                ColorUtility.TryParseHtmlString("#23a86d", out Color thumbBackgroundColor);


                horizontalSlider.normal.background = DrawingUtil.ColoredTexture(sliderBackgroundColor);

                Texture2D thumbTexture = DrawingUtil.ColoredTexture(thumbBackgroundColor);

                horizontalSliderThumb.normal.background = thumbTexture;
                horizontalSliderThumb.hover.background = thumbTexture;
                horizontalSliderThumb.active.background = thumbTexture;
                horizontalSliderThumb.focused.background = thumbTexture;
            }

            return GUILayout.HorizontalSlider(value, minValue, maxValue, horizontalSlider, horizontalSliderThumb);
        }

        public static void Label(string text)
        {
            GUILayout.Label(text);
        }

    }
}
