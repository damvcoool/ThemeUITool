using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(DropdownThemeSelector))]
    public class DropdownThemeSelectorEditor : TThemeSelectorEditor<DropdownThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Dropdown", false, 9)]
        private static void Create(MenuCommand menuCommand)
        {
            GameObject go = ThemeUIToolCreator.CreateDropdown();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}