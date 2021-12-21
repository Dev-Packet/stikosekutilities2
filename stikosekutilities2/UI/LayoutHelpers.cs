using stikosekutilities2.Utils;
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

        public static bool Toggle(string text, bool toggled)
        {
            GUIContent content = new("haha stikosekutilities go brrrrrrrrrr");

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button, GUILayout.Height(40));

            if (GUI.Button(buttonRect, content))
            {
                toggled = !toggled;
            }

            ColorUtility.TryParseHtmlString(ElementHex, out elec);

            // Draw Button
            DrawingUtil.DrawColor(elec, buttonRect);
            // Draw Button text
            DrawingUtil.DrawText(text, new Rect(buttonRect.x + 5, buttonRect.y + 5, buttonRect.width - 10, buttonRect.height - 10), 15, Color.white);
            // Draw toggle border
            DrawingUtil.DrawColor(WindowManager.Border, new Rect(buttonRect.width - 30, buttonRect.y + 5, 30, 30));

            if (toggled)
            {
                DrawingUtil.DrawColor(elec, new Rect(buttonRect.width - 25, buttonRect.y + 10, 20, 20));
            }

            return toggled;
        }

        public static bool Button(string text)
        {
            GUIContent content = new("haha stikosekutilities go brrrrrrrrrr");

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button, GUILayout.Height(40));

            bool clicked = GUI.Button(buttonRect, content);

            ColorUtility.TryParseHtmlString(ElementHex, out elec);

            // Draw Button
            DrawingUtil.DrawColor(elec, buttonRect);
            // Draw Button text
            DrawingUtil.DrawText(text, new Rect(buttonRect.x + 5, buttonRect.y + 5, buttonRect.width - 10, buttonRect.height - 10), 15, Color.white);

            return clicked;
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
