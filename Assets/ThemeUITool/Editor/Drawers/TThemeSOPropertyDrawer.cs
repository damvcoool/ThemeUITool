using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ThemeUI
{
    [CustomPropertyDrawer(typeof(TThemeSO), true)]
    public class TThemeSOPropertyDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            TThemeSO[] themeObjects = ThemeUITool.GetAllThemes(fieldInfo.FieldType);

            // Create an array of TThemeSO names
            var themeNames = new string[themeObjects.Length];
            for (int i = 0; i < themeObjects.Length; i++)
            {
                themeNames[i] = themeObjects[i].name;
            }

            // Find the index of the currently selected TThemeSO
            int currentIndex = -1;
            for (int i = 0; i < themeObjects.Length; i++)
            {
                if (themeObjects[i] == property.objectReferenceValue)
                {
                    currentIndex = i;
                    break;
                }
            }

            // Display a dropdown with the available TThemeSO options
            currentIndex = EditorGUI.Popup(position, label.text, currentIndex, themeNames);

            // Set the selected TThemeSO
            if (currentIndex >= 0 && currentIndex < themeObjects.Length)
            {
                property.objectReferenceValue = themeObjects[currentIndex];
            }
            else
            {
                property.objectReferenceValue = null;
            }

            EditorGUI.EndProperty();
        }
    }
}