using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(SliderThemeSelector))]
    public class SliderThemeSelectorEditor : TThemeSelectorEditor<SliderThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Slider", false, 13)]
        internal static void Create(MenuCommand menuCommand)
        {
            GameObject go = ThemeUIToolCreator.CreateSlider();
            PlaceUIElementRoot(go, menuCommand);
        }
    }
}