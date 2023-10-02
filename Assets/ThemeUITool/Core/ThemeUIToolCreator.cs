#if UNITY_EDITOR

using System.Collections.Generic;
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
            go.GetComponent<ButtonThemeSelector>().TargetButton = go.GetComponent<Button>();
            go.GetComponent<Image>().type = Image.Type.Sliced;

            var tx = new GameObject("Text (TMP)", typeof(TextMeshProUGUI));
            ThemeUITool.SetRectTransformProperties(tx, new Vector4(0, 0, 1, 1), Vector2.zero, Vector3.zero, go);
            tx.GetComponent<TextMeshProUGUI>().text = "Button";
            tx.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;

            go.GetComponent<ButtonThemeSelector>().Text = tx.GetComponent<TextMeshProUGUI>();

            go.GetComponent<ButtonThemeSelector>().ApplyTheme();

            return go;
        }
        internal static GameObject CreateSlider()
        {
            GameObject go = new GameObject("Themed Slider", typeof(RectTransform), typeof(SliderThemeSelector), typeof(Slider));
            go.GetComponent<SliderThemeSelector>().TargetSlider = go.GetComponent<Slider>();

            var bg = new GameObject("Background", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(bg, new Vector4(0, 0.25f, 1, 0.75f), Vector2.zero, Vector3.zero, go);
            bg.GetComponent<Image>().type = Image.Type.Sliced;
            go.GetComponent<SliderThemeSelector>().Background = bg.GetComponent<Image>();

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
            go.GetComponent<ScrollbarThemeSelector>().Background = go.GetComponent<Image>();
            go.GetComponent<ScrollbarThemeSelector>().TargetScrollbar = go.GetComponent<Scrollbar>();
            go.GetComponent<Image>().type = Image.Type.Sliced;

            var sa = new GameObject("Sliding Area", typeof(RectTransform));
            ThemeUITool.SetRectTransformProperties(sa, new Vector4(0, 0, 1, 1), new Vector2(-20, -20), Vector3.zero, go);

            var h = new GameObject("Handle", typeof(Image));
            ThemeUITool.SetRectTransformProperties(h, new Vector4(0, 0, 0.2f, 1), new Vector2(20, 20), Vector3.zero, sa);
            go.GetComponent<Scrollbar>().handleRect = h.GetComponent<RectTransform>();
            go.GetComponent<Scrollbar>().targetGraphic = h.GetComponent<Image>();
            h.GetComponent<Image>().type = Image.Type.Sliced;

            go.GetComponent<ScrollbarThemeSelector>().ApplyTheme();

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
            go.GetComponent<ToggleThemeSelector>().Label = lbl.GetComponent<TextMeshProUGUI>();

            return go;
        }
        internal static GameObject CreateInputField()
        {
            GameObject go = new GameObject("Themed Input Field", typeof(CanvasRenderer), typeof(InputFieldThemeSelector), typeof(Image), typeof(TMP_InputField));

            TMP_InputField _InputField = go.GetComponent<TMP_InputField>();

            go.GetComponent<InputFieldThemeSelector>().TargetInputField = _InputField;
            go.GetComponent<Image>().type = Image.Type.Sliced;

            GameObject ta = new GameObject("TextArea", typeof(RectMask2D));
            ThemeUITool.SetRectTransformProperties(ta, new Vector4(0, 0, 1, 1), new Vector2(-20, -13), new Vector3(0, -0.5f, 0), go);
            _InputField.textViewport = ta.GetComponent<RectTransform>();

            GameObject p = new GameObject("Placeholder", typeof(TextMeshProUGUI));
            TextMeshProUGUI p_Text = p.GetComponent<TextMeshProUGUI>();
            ThemeUITool.SetRectTransformProperties(p, new Vector4(0, 0, 1, 1), Vector2.zero, Vector3.zero, ta);
            p_Text.fontStyle = FontStyles.Italic;
            p_Text.text = "Enter text...";

            GameObject t = new GameObject("Text", typeof(TextMeshProUGUI));
            ThemeUITool.SetRectTransformProperties(t, new Vector4(0, 0, 1, 1), Vector2.zero, Vector3.zero, ta);

            _InputField.textComponent = t.GetComponent<TextMeshProUGUI>();
            _InputField.placeholder = p_Text;

            return go;
        }
        internal static GameObject CreateScrollRect()
        {
            GameObject go = new GameObject("Themed Scroll View", typeof(CanvasRenderer), typeof(ScrollRectThemeSelector), typeof(Image), typeof(ScrollRect));

            ScrollRect _scrollRect = go.GetComponent<ScrollRect>();
            ScrollRectThemeSelector _scrollbarThemeSelector = go.GetComponent<ScrollRectThemeSelector>();

            _scrollbarThemeSelector.TargetScrollRect = _scrollRect;
            _scrollbarThemeSelector.Background = go.GetComponent<Image>();
            go.GetComponent<Image>().type = Image.Type.Sliced;

            GameObject v = new GameObject("Viewport", typeof(Image), typeof(Mask));
            v.GetComponent<Image>().type = Image.Type.Sliced;
            v.GetComponent<Mask>().showMaskGraphic = false;
            ThemeUITool.SetRectTransformProperties(v, new Vector4(0, 0, 1, 1), new Vector2(-17, -17), Vector3.zero, go);
            v.GetComponent<RectTransform>().pivot = Vector2.up;
            _scrollRect.viewport = v.GetComponent<RectTransform>();

            GameObject c = new GameObject("Content", typeof(RectTransform));
            c.GetComponent<RectTransform>().pivot = Vector2.up;
            ThemeUITool.SetRectTransformProperties(c, new Vector4(0, 1, 1, 1), new Vector2(0, 300), Vector3.zero, v);
            _scrollRect.content = c.GetComponent<RectTransform>();

            GameObject sh = CreateScrollbar();
            sh.name = "Themed Scrollbar Horizontal";
            ThemeUITool.SetRectTransformProperties(sh, new Vector4(0, 0, 1, 0), new Vector2(-20, 0), Vector3.zero, go);
            sh.GetComponent<RectTransform>().pivot = Vector2.zero;
            _scrollRect.horizontalScrollbar = sh.GetComponent<Scrollbar>();

            GameObject sv = CreateScrollbar();
            sv.name = "Themed Scrollbar Vertical";
            ThemeUITool.SetRectTransformProperties(sv, new Vector4(1, 0, 1, 1), new Vector2(0, -20), Vector3.zero, go);
            sv.GetComponent<RectTransform>().pivot = Vector2.one;
            sv.GetComponent<Scrollbar>().value = 1;
            _scrollRect.verticalScrollbar = sv.GetComponent<Scrollbar>();

            return go;
        }
        internal static GameObject CreateDropdown()
        {
            GameObject go = new GameObject("Themed Dropdown", typeof(CanvasRenderer), typeof(DropdownThemeSelector), typeof(Image), typeof(TMP_Dropdown));
            TMP_Dropdown _dropdown = go.GetComponent<TMP_Dropdown>();
            DropdownThemeSelector _selector = go.GetComponent<DropdownThemeSelector>();
            go.GetComponent<Image>().type = Image.Type.Sliced;

            GameObject l = new GameObject("Label", typeof(TextMeshProUGUI));
            ThemeUITool.SetRectTransformProperties(l, new Vector4(0, 0, 1, 1), new Vector2(-35, -13), new Vector3(-7.5f, -0.5f, 0), go);
            _dropdown.captionText = l.GetComponent<TextMeshProUGUI>();
            _dropdown.captionText.alignment = TextAlignmentOptions.Left | TextAlignmentOptions.Center;

            GameObject a = new GameObject("Arrow", typeof(Image));
            ThemeUITool.SetRectTransformProperties(a, new Vector4(1, 0.5f, 1, 0.5f), new Vector2(20, 20), new Vector3(-15, 0, 0), go);

            GameObject t = CreateScrollRect();
            t.name = "Template";
            ScrollRect _scrollrect = t.GetComponent<ScrollRect>();
            t.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
            ThemeUITool.SetRectTransformProperties(t, new Vector4(0, 0, 1, 0), new Vector2(0, 150), new Vector3(0, 2, 0), go);
            _scrollrect.content.sizeDelta = new Vector2(0, 28);
            _dropdown.template = t.GetComponent<RectTransform>();

            GameObject i = CreateToggle();
            Toggle _toggle = i.GetComponent<Toggle>();
            ToggleThemeSelector _toggleSelector = i.GetComponent<ToggleThemeSelector>();
            i.name = "Item";
            ThemeUITool.SetRectTransformProperties(i, new Vector4(0, 0.5f, 1, 0.5f), new Vector2(0, 20), new Vector3(), t.GetComponent<ScrollRect>().content.gameObject);
            ThemeUITool.SetRectTransformProperties(_toggle.image.gameObject, new Vector4(0, 0, 1, 1), Vector2.zero, Vector3.zero);
            ThemeUITool.SetRectTransformProperties(_toggle.graphic.gameObject, new Vector4(0, 0.5f, 0, 0.5f), new Vector2(20, 20), new Vector3(10,0,0), _toggle.gameObject);
            ThemeUITool.SetRectTransformProperties(_toggleSelector.Label.gameObject, new Vector4(0,0,1,1), new Vector2(-30,-3), new Vector3(5,-0.5f,0));
            
            _toggleSelector.Label.gameObject.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left | TextAlignmentOptions.Center; ;
            _dropdown.itemText = i.GetComponent<ToggleThemeSelector>().Label;

            _selector.TargetDropdown = _dropdown;
            _selector.Arrow = a.GetComponent<Image>();
            _selector.Item = i.GetComponent<ToggleThemeSelector>();
            _toggleSelector.Label.text = "Option A";
            _dropdown.AddOptions(new List<string> { "Option A", "Option B", "Option C" });

            t.SetActive(false);
            return go;
        }
    }
}
#endif