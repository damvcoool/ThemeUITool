#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using static UnityEditor.Rendering.FilterWindow;

namespace ThemeUITool
{
    public static class ThemeCreateMenuItems
    {
        [MenuItem("GameObject/Themed UI/Button", false, 8)]
        public static void AddButton(MenuCommand menuCommand)
        {
            GameObject go = TMP_DefaultControls.CreateButton(new TMP_DefaultControls.Resources());
            go.gameObject.name = "Themed Button";

            // Create or assign a valid ButtonThemeSO asset to the theme property
            ButtonThemeSO buttonTheme = (ButtonThemeSO)ThemeUITool.GetAllThemes(typeof(ButtonThemeSO)).FirstOrDefault();
            var buttonThemeSelector = go.AddComponent<ButtonThemeSelector>();

            // Explicitly set the theme property
            buttonThemeSelector.m_Theme = buttonTheme;

            buttonThemeSelector.targetButton = go.GetComponent<Button>();
            buttonThemeSelector.buttonText = go.GetComponentInChildren<TMP_Text>();

            buttonThemeSelector.ApplyTheme();

            PlaceUIElementRoot(go, menuCommand);
        }
        [MenuItem("GameObject/Themed UI/Slider", false, 8)]
        public static void AddSlider(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Slider", typeof(RectTransform), typeof(SliderThemeSelector), typeof(Slider));
            go.GetComponent<SliderThemeSelector>().m_Theme = (SliderThemeSO)ThemeUITool.GetAllThemes(typeof(SliderThemeSO)).FirstOrDefault();
            go.GetComponent<SliderThemeSelector>().targetSlider = go.GetComponent<Slider>();

            var bg = new GameObject("Background", typeof(CanvasRenderer), typeof(Image));
            SetRectTransformProperties(bg,new Vector4(0,0.25f,1,0.75f), Vector2.zero, Vector3.zero, go);
            bg.GetComponent<Image>().type = Image.Type.Sliced;
            go.GetComponent<SliderThemeSelector>().sliderBackground = bg.GetComponent<Image>();

            var fa = new GameObject("Fill Area", typeof(RectTransform));
            SetRectTransformProperties(fa, new Vector4(0, 0.25f, 1, 0.75f),new Vector2(-20,0),new Vector3(-5f,0,0), go);

            var f = new GameObject("Fill", typeof(CanvasRenderer), typeof(Image));
            SetRectTransformProperties(f, new Vector4(0, 0, 0, 1), new Vector2(10, 0), new Vector3(-5,0,0), fa);
            go.GetComponent<Slider>().fillRect = f.GetComponent<RectTransform>();
            f.GetComponent<Image>().type = Image.Type.Sliced;

            var hsa = new GameObject("Handle Slide Area", typeof(RectTransform));
            SetRectTransformProperties(hsa, new Vector4(0, 0, 1, 1), new Vector2(-20, 0), new Vector3(0f, 0, 0), go);

            var h = new GameObject("Handle", typeof(CanvasRenderer), typeof(Image));
            SetRectTransformProperties(h, new Vector4(0, 0, 0, 1), new Vector2(-5, 0), new Vector3(0, 0, 0), hsa);
            go.GetComponent<Slider>().handleRect = h.GetComponent<RectTransform>();
            h.GetComponent<Image>().type = Image.Type.Simple;

            go.GetComponent<SliderThemeSelector>().ApplyTheme();

            PlaceUIElementRoot(go, menuCommand);
        }

        private static void SetRectTransformProperties(GameObject target, Vector4 anchorMinMax, Vector2 size, Vector3 position, GameObject parent = null)
        {
            if (parent != null) target.transform.SetParent(parent.transform, false);
            target.GetComponent<RectTransform>().sizeDelta = size;
            target.GetComponent<RectTransform>().position = position;
            target.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMinMax.x, anchorMinMax.y);
            target.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMinMax.z, anchorMinMax.w);

        }

        internal static void PlaceUIElementRoot(GameObject go, MenuCommand menuCommand)
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