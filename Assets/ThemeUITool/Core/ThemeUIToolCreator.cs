#if UNITY_EDITOR
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    internal static class ThemeUIToolCreator
    {
        internal static GameObject CreateButton()
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

            return go;
        }
        internal static GameObject CreateSlider()
        {
            GameObject go = new GameObject("Themed Slider", typeof(RectTransform), typeof(SliderThemeSelector), typeof(Slider));
            go.GetComponent<SliderThemeSelector>().targetSlider = go.GetComponent<Slider>();

            var bg = new GameObject("Background", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(bg, new Vector4(0, 0.25f, 1, 0.75f), Vector2.zero, Vector3.zero, go);
            bg.GetComponent<Image>().type = Image.Type.Sliced;
            go.GetComponent<SliderThemeSelector>().sliderBackground = bg.GetComponent<Image>();

            var fa = new GameObject("Fill Area", typeof(RectTransform));
            ThemeUITool.SetRectTransformProperties(fa, new Vector4(0, 0.25f, 1, 0.75f), new Vector2(-20, 0), new Vector3(-5f, 0, 0), go);

            var f = new GameObject("Fill", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(f, new Vector4(0, 0, 0, 1), new Vector2(10, 0), Vector3.zero, fa);
            go.GetComponent<Slider>().fillRect = f.GetComponent<RectTransform>();
            f.GetComponent<Image>().type = Image.Type.Sliced;

            var hsa = new GameObject("Handle Slide Area", typeof(RectTransform));
            ThemeUITool.SetRectTransformProperties(hsa, new Vector4(0, 0, 1, 1), new Vector2(-20, 0), new Vector3(0f, 0, 0), go);

            var h = new GameObject("Handle", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(h, new Vector4(0, 0, 0, 1), new Vector2(-5, 0), new Vector3(0, 0, 0), hsa);
            go.GetComponent<Slider>().handleRect = h.GetComponent<RectTransform>();
            go.GetComponent<Slider>().targetGraphic = h.GetComponent<Image>();
            h.GetComponent<Image>().type = Image.Type.Simple;

            go.GetComponent<SliderThemeSelector>().ApplyTheme();

            return go;
        }

        internal static GameObject CreateScrollbar()
        {
            GameObject go = new GameObject("Themed Scrollbar", typeof(RectTransform), typeof(ScrollbarThemeSelector), typeof(Image), typeof(Scrollbar));
            go.GetComponent<ScrollbarThemeSelector>().scrollbarBackground = go.GetComponent<Image>();
            go.GetComponent<ScrollbarThemeSelector>().targetScrollbar = go.GetComponent<Scrollbar>();
            go.GetComponent<Image>().type = Image.Type.Sliced;

            var sa = new GameObject("Sliding Area", typeof(RectTransform));
            ThemeUITool.SetRectTransformProperties(sa, new Vector4(0, 0, 1, 1), new Vector2(-20, -20), Vector3.zero, go);

            var h = new GameObject("Handle", typeof(Image));
            ThemeUITool.SetRectTransformProperties(h, new Vector4(0, 0, 0.2f, 1), new Vector2(20, 20), Vector3.zero, sa);
            go.GetComponent<Scrollbar>().handleRect = h.GetComponent<RectTransform>();
            go.GetComponent<Scrollbar>().targetGraphic = h.GetComponent<Image>();
            h.GetComponent<Image>().type = Image.Type.Sliced;

            go.GetComponent<ButtonThemeSelector>().ApplyTheme();

            return go;
        }
        internal static GameObject CreateToggle()
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

            return go;
        }
        internal static GameObject CreateInputField()
        {
            GameObject go = new GameObject("Themed Input Field");

            // Needs Implementation

            return go;
        }
        internal static GameObject CreateDropdown()
        {
            GameObject go = new GameObject("Themed Dropdown");
            
            // Needs Implementation
            
            return go;
        }
        internal static GameObject CreateScrollRect()
        {
            GameObject go = new GameObject("Themed ScrollRect");

            // Needs Implementation

            return go;
        }
    }
}
#endif