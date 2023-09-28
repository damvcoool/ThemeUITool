using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

namespace ThemedUITool
{
    [CustomEditor(typeof(TThemeSelector<>), true)]
    public abstract class TThemeSelectorEditor<T> : Editor where T : TThemeSO
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            TThemeSelector<T> themeSelector = (TThemeSelector<T>)target;

            DrawPropertiesExcluding(serializedObject, "m_Script");

            if (themeSelector.Validate)
            {
                themeSelector.ApplyTheme();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private protected static void PlaceUIElementRoot(GameObject go, MenuCommand menuCommand)
        {
            GameObject parent = menuCommand.context as GameObject;

            if (parent == null)
            {
                var canvas = FindFirstObjectByType<Canvas>();
                if (canvas == null)
                {
                    GameObject canvasGo = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
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