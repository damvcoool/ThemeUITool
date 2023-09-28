using UnityEditor;

namespace ThemedUITool
{
    [CustomEditor(typeof(InputFieldThemeSelector))]
    public class InputFieldThemeSelectorEditor : TThemeSelectorEditor<InputFieldThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Input Field", false, 10)]
        public static void AddInputField(MenuCommand menuCommand) { }
    }
}
