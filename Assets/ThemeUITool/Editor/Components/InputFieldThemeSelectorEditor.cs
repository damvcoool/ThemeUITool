using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(InputFieldThemeSelector))]
    public class InputFieldThemeSelectorEditor : TThemeSelectorEditor<InputFieldThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Input Field", false, 10)]
        private static void Create(MenuCommand menuCommand) 
        {
            GameObject go = ThemeUIToolCreator.CreateInputField();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}