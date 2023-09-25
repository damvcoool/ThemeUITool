#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.Linq;
//using System.Linq;

namespace ThemeUI
{
    public static class ThemeCreateMenuItems
    {
        [MenuItem("GameObject/Themed UI/Button", false, 8)]
        public static void AddButton(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Button", typeof(CanvasRenderer),typeof(ButtonThemeSelector), typeof(Image), typeof(Button));
            go.GetComponent<ButtonThemeSelector>().theme = (ButtonThemeSO)ThemeUITool.GetDefaultTheme(typeof(ButtonThemeSO));
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
        [MenuItem("GameObject/Themed UI/Slider", false, 8)]
        public static void AddSlider(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Slider", typeof(RectTransform), typeof(SliderThemeSelector), typeof(Slider));
            go.GetComponent<SliderThemeSelector>().theme = (SliderThemeSO)ThemeUITool.GetDefaultTheme(typeof(SliderThemeSO));
            go.GetComponent<SliderThemeSelector>().targetSlider = go.GetComponent<Slider>();

            var bg = new GameObject("Background", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(bg,new Vector4(0,0.25f,1,0.75f), Vector2.zero, Vector3.zero, go);
            bg.GetComponent<Image>().type = Image.Type.Sliced;
            go.GetComponent<SliderThemeSelector>().sliderBackground = bg.GetComponent<Image>();

            var fa = new GameObject("Fill Area", typeof(RectTransform));
            ThemeUITool.SetRectTransformProperties(fa, new Vector4(0, 0.25f, 1, 0.75f),new Vector2(-20,0),new Vector3(-5f,0,0), go);

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

            PlaceUIElementRoot(go, menuCommand);
        }
        [MenuItem("GameObject/Themed UI/Toggle", false, 8)]
        public static void AddToggle(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Toggle", typeof(RectTransform),typeof(ToggleThemeSelector),typeof(Toggle));
            go.GetComponent<ToggleThemeSelector>().theme = (ToggleThemeSO)ThemeUITool.GetDefaultTheme(typeof(ToggleThemeSO));
            go.GetComponent<ToggleThemeSelector>().targetToggle = go.GetComponent<Toggle>();
            go.GetComponent<Toggle>().isOn = true;

            var bg = new GameObject("Background", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(bg, new Vector4(0, 1, 0, 1), new Vector2(20,20), new Vector3(10,-10,0), go);
            bg.GetComponent<Image>().type = Image.Type.Sliced;
            go.GetComponent<Toggle>().targetGraphic = bg.GetComponent<Image>();

            var ck = new GameObject("Checkmark", typeof(CanvasRenderer), typeof(Image));
            ThemeUITool.SetRectTransformProperties(ck, new Vector4(0.5f, 0.5f, 0.5f, 0.5f), new Vector2(20, 20), Vector3.zero, bg);
            ck.GetComponent<Image>().type = Image.Type.Simple;
            go.GetComponent<Toggle>().graphic = ck.GetComponent<Image>();

            var lbl = new GameObject("Label",typeof(CanvasRenderer),typeof(TextMeshProUGUI));
            ThemeUITool.SetRectTransformProperties(lbl, new Vector4(0, 0, 1, 1), new Vector2(-28,-3), new Vector3(9,-0.5f,0), go);
            lbl.GetComponent<TextMeshProUGUI>().text = "Toggle";
            go.GetComponent<ToggleThemeSelector>().sliderLabel = lbl.GetComponent<TextMeshProUGUI>();

            PlaceUIElementRoot (go, menuCommand);
        }

        private static void PlaceUIElementRoot(GameObject go, MenuCommand menuCommand)
        {
            GameObject parent = menuCommand.context as GameObject;

            if (parent == null)
            {
                var canvas = GameObject.FindFirstObjectByType<Canvas>();
                if (canvas == null)
                {
                    GameObject canvasGo = new GameObject("Canvas", typeof(Canvas),typeof(CanvasScaler), typeof(GraphicRaycaster));
                    canvas = canvasGo.GetComponent<Canvas>();
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                    canvasGo.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ConstantPhysicalSize;
                    
                }
                parent = canvas.gameObject;
            }
            go.transform.SetParent(parent.transform);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;

            Selection.activeGameObject = go;
        }
    }
}
#endif