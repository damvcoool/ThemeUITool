using UnityEditor;

namespace ThemedUITool
{
    [CustomEditor(typeof(DropdownThemeSelector))]
    public class DropdownThemeSelectorEditor : TThemeSelectorEditor<InputFieldThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Dropdown", false, 9)]
        public static void AddDropdown(MenuCommand menuCommand) { }
    }
}
