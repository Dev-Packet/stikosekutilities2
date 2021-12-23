using stikosekutilities2.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class Items : BaseCheat
    {
        public static List<InventoryItem> SuItems = new();

        private Vector2 scrollPosition;

        public Items() : base("Items", WindowID.Items)
        {
            scrollPosition = Vector2.zero;
        }

        protected override void RenderElements()
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true);

            int firstIndex = (int)(scrollPosition.y / 69);
            firstIndex = Mathf.Clamp(firstIndex, 0, SuItems.Count);
            //GUILayout.Space(firstIndex * 69);

            try
            {
                for (int i = firstIndex; i < SuItems.Count; i++)
                {
                    InventoryItem item = SuItems[i];

                    if (ItemButton(item.sprite, scrollPosition))
                    {
                        InventoryUI.Instance.AddItemToInventory(item);
                    }
                }
            } catch(Exception)
            {

            }
            

            GUILayout.EndScrollView();
        }

    }
}
