using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(ToggleThemeSelector))]
    public class ToggleThemeSelectorEditor : TThemeSelectorEditor<ToggleThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Toggle", false, 14)]
        private static void Create(MenuCommand menuCommand) 
        {
            GameObject go = ThemeUIToolCreator.CreateToggle();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}