using UnityEditor;

namespace ThemedUITool
{
    [CustomEditor(typeof(ScrollViewThemeSelector))]
    public class ScrollViewThemeSelectorEditor : TThemeSelectorEditor<InputFieldThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Scroll View", false, 12)]
        public static void AddScrollView(MenuCommand menuCommand) { }
    }
}