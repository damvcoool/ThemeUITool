using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

namespace ThemeUI
{
    [CustomEditor(typeof(ScrollbarThemeSelector))]
    public class ScrollbarThemeSelectorEditor : TThemeSelectorEditor<ScrollbarThemeSO>
    {
        [MenuItem("GameObject/Themed UI/Scrollbar", false, 8)]
        public static void AddScrollbar(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Themed Scrollbar", typeof(RectTransform), typeof(ScrollbarThemeSelector), typeof(Image), typeof(Scrollbar));
            go.GetComponent<ScrollbarThemeSelector>().scrollbarBackground = go.GetComponent<Image>();
            go.GetComponent<ScrollbarThemeSelector>().targetScrollbar = go.GetComponent<Scrollbar>();
            go.GetComponent<Image>().type = Image.Type.Sliced;
            

            var sa = new GameObject("Sliding Area", typeof(RectTransform));
            ThemeUITool.SetRectTransformProperties(sa, new Vector4(0, 0, 1, 1), new Vector2(-20,-20), Vector3.zero, go);

            var h = new GameObject("Handle", typeof(Image));
            ThemeUITool.SetRectTransformProperties(h, new Vector4(0, 0, 0.2f, 1), new Vector2(20, 20), Vector3.zero, sa);
            go.GetComponent<Scrollbar>().handleRect = h.GetComponent<RectTransform>();
            go.GetComponent<Scrollbar>().targetGraphic = h.GetComponent<Image>();
            h.GetComponent<Image>().type = Image.Type.Sliced;


            //go.GetComponent<ButtonThemeSelector>().ApplyTheme();

            PlaceUIElementRoot(go, menuCommand);
        }
    }
}
