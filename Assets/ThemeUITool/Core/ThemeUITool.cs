#if UNITY_EDITOR

using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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

        public static T[] GetAllThemes<T>() where T : TThemeSO
        {
            Type type = typeof(TThemeSO);
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

            return themeObjects.Cast<T>().ToArray();
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

        public static T GetDefaultTheme<T>() where T : TThemeSO
        {
            // Determine the type at runtime
            Type type = typeof(T);

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
            themeObjects = Array.FindAll(themeObjects, theme => type.IsAssignableFrom(theme.GetType()));

            // Create the default Theme name based on the type
            string name = "Default" + type.Name;

            // Find and return the default Theme
            return themeObjects.FirstOrDefault(theme => theme.name.Equals(name.Substring(0, name.Length - 2))) as T;
        }

        public static void SetRectTransformProperties(GameObject target, Vector4 anchorMinMax, Vector2 size, Vector3 position, GameObject parent = null)
        {
            if (parent != null) target.transform.SetParent(parent.transform, false);

            target.GetComponent<RectTransform>().sizeDelta = size;
            target.GetComponent<RectTransform>().anchoredPosition3D = position;
            target.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMinMax.x, anchorMinMax.y);
            target.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMinMax.z, anchorMinMax.w);
        }
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
    }
}
#endif