using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(ScrollViewThemeSelector))]
    public class ScrollViewThemeSelectorEditor : TThemeSelectorEditor<InputFieldThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Scroll View", false, 12)]
        private static void Create(MenuCommand menuCommand) 
        {
            GameObject go = ThemeUIToolCreator.CreateScrollRect();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}