#if UNITY_EDITOR

using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    public static class ThemeUITool
    {
        #region GetThemes
        
        /// <summary>
        /// Helper method to load all TThemeSO assets from the project
        /// </summary>
        /// <returns>Array of all theme assets found in the project</returns>
        private static TThemeSO[] LoadAllThemeAssets()
        {
            var tThemes = AssetDatabase.FindAssets("t:TThemeSO");
            var themeObjects = new TThemeSO[tThemes.Length];

            for (int i = 0; i < tThemes.Length; i++)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(tThemes[i]);
                themeObjects[i] = AssetDatabase.LoadAssetAtPath<TThemeSO>(assetPath);
            }

            return themeObjects;
        }

        /// <summary>
        /// Gets all theme assets of the specified type
        /// </summary>
        /// <param name="type">The type of theme to retrieve</param>
        /// <returns>Array of all themes matching the specified type</returns>
        public static TThemeSO[] GetAllThemes(Type type)
        {
            var themeObjects = LoadAllThemeAssets();
            return Array.FindAll(themeObjects, theme => type.IsAssignableFrom(theme.GetType()));
        }
        
        /// <summary>
        /// Gets all theme assets of the specified type
        /// </summary>
        /// <typeparam name="T">The type of theme to retrieve</typeparam>
        /// <returns>Array of all themes matching the specified type</returns>
        public static T[] GetAllThemes<T>() where T : TThemeSO
        {
            Type type = typeof(T);
            var themeObjects = LoadAllThemeAssets();
            themeObjects = Array.FindAll(themeObjects, theme => type.IsAssignableFrom(theme.GetType()));
            return themeObjects.Cast<T>().ToArray();
        }
        
        /// <summary>
        /// Gets the default theme for the specified type. The default theme must be named "Default{TypeName}"
        /// </summary>
        /// <param name="type">The type of theme to retrieve</param>
        /// <returns>The default theme, or null if not found</returns>
        public static TThemeSO GetDefaultTheme(Type type)
        {
            var themeObjects = LoadAllThemeAssets();
            themeObjects = Array.FindAll(themeObjects, theme => type.IsAssignableFrom(theme.GetType()));
            string name = "Default" + type.Name;
            return themeObjects.FirstOrDefault(theme => theme.name.Equals(name.Substring(0, name.Length - 2)));
        }
        
        /// <summary>
        /// Gets the default theme for the specified type. The default theme must be named "Default{TypeName}"
        /// </summary>
        /// <typeparam name="T">The type of theme to retrieve</typeparam>
        /// <returns>The default theme, or null if not found</returns>
        public static T GetDefaultTheme<T>() where T : TThemeSO
        {
            Type type = typeof(T);
            var themeObjects = LoadAllThemeAssets();
            themeObjects = Array.FindAll(themeObjects, theme => type.IsAssignableFrom(theme.GetType()));
            string name = "Default" + type.Name;
            return themeObjects.FirstOrDefault(theme => theme.name.Equals(name.Substring(0, name.Length - 2))) as T;
        }
        
        /// <summary>
        /// Gets a specific theme by name
        /// </summary>
        /// <typeparam name="T">The type of theme to retrieve</typeparam>
        /// <param name="themeName">The name of the theme asset</param>
        /// <returns>The theme with the specified name, or null if not found</returns>
        public static T GetSpecificTheme<T>(string themeName) where T : TThemeSO
        {
            Type type = typeof(T);
            var themeObjects = LoadAllThemeAssets();
            themeObjects = Array.FindAll(themeObjects, theme => type.IsAssignableFrom(theme.GetType()));
            return themeObjects.FirstOrDefault(theme => theme.name.Equals(themeName)) as T;
        }
        #endregion
        #region SetProperties
        
        /// <summary>
        /// Sets the RectTransform properties of a UI element
        /// </summary>
        /// <param name="target">The GameObject to modify</param>
        /// <param name="anchorMinMax">Vector4 containing anchor min (x,y) and anchor max (z,w)</param>
        /// <param name="size">The size delta of the RectTransform</param>
        /// <param name="position">The anchored position of the element</param>
        /// <param name="parent">Optional parent GameObject to set</param>
        public static void SetRectTransformProperties(GameObject target, Vector4 anchorMinMax, Vector2 size, Vector3 position, GameObject parent = null)
        {
            if (parent != null) target.transform.SetParent(parent.transform, false);

            target.GetComponent<RectTransform>().anchoredPosition3D = position;
            target.GetComponent<RectTransform>().sizeDelta = size;
            target.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMinMax.x, anchorMinMax.y);
            target.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMinMax.z, anchorMinMax.w);
        }
        
        /// <summary>
        /// Adds or configures a shadow effect on a UI element
        /// </summary>
        /// <param name="target">The GameObject to add the shadow to</param>
        /// <param name="addShadow">Whether to enable the shadow effect</param>
        /// <param name="shadowOffset">The offset of the shadow</param>
        /// <param name="shadowColor">The color of the shadow</param>
        public static void SetShadow(GameObject target, bool addShadow, Vector2 shadowOffset, Color shadowColor)
        {
            Shadow shadow = target.GetComponent<Shadow>();
            if (addShadow)
            {
                if (shadow == null)
                {
                    shadow = target.AddComponent<Shadow>();
                }
                else
                {
                    shadow.enabled = true;

                }
                shadow.effectDistance = shadowOffset;
                shadow.effectColor = shadowColor;
            }
            else if (!addShadow && target.GetComponent<Shadow>() != null)
            {
                shadow.enabled = false;
            }
        }

        /// <summary>
        /// Applies theme properties to a TextMeshPro text component
        /// </summary>
        /// <param name="target">The TextMeshPro text component to theme</param>
        /// <param name="themeFontSize">The font size to apply</param>
        /// <param name="themeFont">The font asset to apply (can be null)</param>
        /// <param name="themeColor">The text color to apply</param>
        public static void SetTextTheme(TMP_Text target, float themeFontSize, TMP_FontAsset themeFont, Color themeColor)
        {
            if (target != null)
            {
                target.fontSize = themeFontSize;
                target.color = themeColor;
                if (themeFont != null)
                {
                    target.font = themeFont;
                }
            }
        }

        /// <summary>
        /// Applies theme properties to an Image component
        /// </summary>
        /// <param name="target">The Image component to theme</param>
        /// <param name="themeSprite">The sprite to apply</param>
        /// <param name="themeColor">The color to apply</param>
        /// <param name="themeWith">Optional width override</param>
        /// <param name="themeHeight">Optional height override</param>
        public static void SetImageTheme(Image target, Sprite themeSprite, Color themeColor, float? themeWith = null, float? themeHeight = null)
        {
            if (target != null)
            {
                target.sprite = themeSprite;
                target.color = themeColor;

                RectTransform rt = target.GetComponent<RectTransform>();

                float x = (themeWith != null) ? themeWith.Value : rt.sizeDelta.x;
                float y = (themeHeight != null) ? themeHeight.Value : rt.sizeDelta.y;

                Vector2 wh = new Vector2(x, y);

                target.GetComponent<RectTransform>().sizeDelta = wh;

            }
        }
        #endregion
    }
}
#endif