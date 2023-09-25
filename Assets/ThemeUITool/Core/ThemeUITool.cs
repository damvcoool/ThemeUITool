#if UNITY_EDITOR

using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ThemeUI
{
    public static class ThemeUITool
    {
        public static TThemeSO[] GetAllThemes(Type type)
        {
            // Get all TThemeSO assets in the project
            var tThemes = AssetDatabase.FindAssets("t:TThemeSO");
            var themeObjects = new TThemeSO[tThemes.Length];

            // Convert asset GUIDs to TThemeSO objects
            for (int i = 0; i < tThemes.Length; i++)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(tThemes[i]);
                themeObjects[i] = AssetDatabase.LoadAssetAtPath<TThemeSO>(assetPath);
            }

            // Filter themeObjects based on the specific derived type
            var derivedType = type;
            themeObjects = Array.FindAll(themeObjects, theme => derivedType.IsAssignableFrom(theme.GetType()));

            return themeObjects;
        }

        public static TThemeSO GetDefaultTheme(Type type)
        {
            // Get all TThemeSO assets in the project
            var tThemes = AssetDatabase.FindAssets("t:TThemeSO");
            var themeObjects = new TThemeSO[tThemes.Length];

            // Convert asset GUIDs to TThemeSO objects
            for (int i = 0; i < tThemes.Length; i++)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(tThemes[i]);
                themeObjects[i] = AssetDatabase.LoadAssetAtPath<TThemeSO>(assetPath);
            }

            // Filter themeObjects based on the specific derived type
            var derivedType = type;
            themeObjects = Array.FindAll(themeObjects, theme => derivedType.IsAssignableFrom(theme.GetType()));
            string name = "Default" + type.Name;
            return themeObjects.FirstOrDefault(theme => theme.name.Equals(name.Substring(0, name.Length - 2)));
        }
        public static void SetRectTransformProperties(GameObject target, Vector4 anchorMinMax, Vector2 size, Vector3 position, GameObject parent = null)
        {
            if (parent != null) target.transform.SetParent(parent.transform, false);

            target.GetComponent<RectTransform>().sizeDelta = size;
            target.GetComponent<RectTransform>().anchoredPosition3D = position;
            target.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMinMax.x, anchorMinMax.y);
            target.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMinMax.z, anchorMinMax.w);
        }
    }
}
#endif