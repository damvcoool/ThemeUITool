using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    [CustomEditor(typeof(SliderThemeSelector))]
    public class SliderThemeSelectorEditor : TThemeSelectorEditor<SliderThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Slider", false, 8)]
        public static void AddSlider(MenuCommand menuCommand)
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

            PlaceUIElementRoot(go, menuCommand);
        }
    }
}
