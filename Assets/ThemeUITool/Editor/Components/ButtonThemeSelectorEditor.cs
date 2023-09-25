using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    [CustomEditor(typeof(ButtonThemeSelector))]
    public class ButtonThemeSelectorEditor : TThemeSelectorEditor<ButtonThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Button", false, 8)]
        public static void AddButton(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Button", typeof(CanvasRenderer), typeof(ButtonThemeSelector), typeof(Image), typeof(Button));
            go.GetComponent<ButtonThemeSelector>().targetButton = go.GetComponent<Button>();
            go.GetComponent<Image>().type = Image.Type.Sliced;

            var tx = new GameObject("Text (TMP)", typeof(TextMeshProUGUI));
            ThemeUITool.SetRectTransformProperties(tx, new Vector4(0, 0, 1, 1), Vector2.zero, Vector3.zero, go);
            tx.GetComponent<TextMeshProUGUI>().text = "Button";
            tx.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;

            go.GetComponent<ButtonThemeSelector>().buttonText = tx.GetComponent<TextMeshProUGUI>();

            go.GetComponent<ButtonThemeSelector>().ApplyTheme();

            PlaceUIElementRoot(go, menuCommand);
        }
    }
}
