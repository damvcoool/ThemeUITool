using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(ScrollbarThemeSelector))]
    public class ScrollbarThemeSelectorEditor : TThemeSelectorEditor<ScrollbarThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Scrollbar", false, 11)]
        private static void Create(MenuCommand menuCommand) 
        {
            GameObject go = ThemeUIToolCreator.CreateScrollbar();
            PlaceUIElementRoot(go, menuCommand);
        }

    }
}
