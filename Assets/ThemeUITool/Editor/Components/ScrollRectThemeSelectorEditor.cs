using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(ScrollRectThemeSelector))]
    public class ScrollRectThemeSelectorEditor : TThemeSelectorEditor<ScrollRectThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Scroll View", false, 12)]
        private static void Create(MenuCommand menuCommand) 
        {
            GameObject go = ThemeUIToolCreator.CreateScrollRect();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}