using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    [CustomEditor(typeof(ToggleThemeSelector))]
    public class ToggleThemeSelectorEditor : TThemeSelectorEditor<ToggleThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Toggle", false, 8)]
        public static void AddToggle(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Toggle", typeof(RectTransform), typeof(ToggleThemeSelector), typeof(Toggle));
            go.GetComponent<ToggleThemeSelector>().targetToggle = go.GetComponent<Toggle>();
            go.GetComponent<Toggle>().isOn = true;

            var bg = new GameObject("Background", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(bg, new Vector4(0, 1, 0, 1), new Vector2(20, 20), new Vector3(10, -10, 0), go);
            bg.GetComponent<Image>().type = Image.Type.Sliced;
            go.GetComponent<Toggle>().targetGraphic = bg.GetComponent<Image>();

            var ck = new GameObject("Checkmark", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(ck, new Vector4(0.5f, 0.5f, 0.5f, 0.5f), new Vector2(20, 20), Vector3.zero, bg);
            ck.GetComponent<Image>().type = Image.Type.Simple;
            go.GetComponent<Toggle>().graphic = ck.GetComponent<Image>();

            var lbl = new GameObject("Label", typeof(CanvasRenderer), typeof(TextMeshProUGUI));
            ThemeUITool.SetRectTransformProperties(lbl, new Vector4(0, 0, 1, 1), new Vector2(-28, -3), new Vector3(9, -0.5f, 0), go);
            lbl.GetComponent<TextMeshProUGUI>().text = "Toggle";
            go.GetComponent<ToggleThemeSelector>().sliderLabel = lbl.GetComponent<TextMeshProUGUI>();

            PlaceUIElementRoot(go, menuCommand);
        }
    }
}
