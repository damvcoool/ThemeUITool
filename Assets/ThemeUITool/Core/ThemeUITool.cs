#if UNITY_EDITOR

using System;
using UnityEditor;

namespace ThemeUITool
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
    }
}
#endif