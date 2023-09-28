using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(ButtonThemeSelector))]
    internal class ButtonThemeSelectorEditor : TThemeSelectorEditor<ButtonThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Button", false, 8)]
        private static void Create(MenuCommand menuCommand)
        {
            GameObject go = ThemeUIToolCreator.CreateButton();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}