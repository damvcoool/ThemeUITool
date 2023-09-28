using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomPropertyDrawer(typeof(TThemeSO), true)]
    public class TThemeSOPropertyDrawer : PropertyDrawer
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

            // Calculate the position for the dropdown
            Rect dropdownPosition = new Rect(position.x, position.y, position.width - 20, position.height);

            // Display a dropdown with the available TThemeSO options
            currentIndex = EditorGUI.Popup(dropdownPosition, label.text, currentIndex, themeNames);

            // Set the selected TThemeSO
            if (currentIndex >= 0 && currentIndex < themeObjects.Length)
            {
                property.objectReferenceValue = themeObjects[currentIndex];
            }
            else
            {
                property.objectReferenceValue = null;
            }

            // Create a button with letter "O" to open the Scriptable Object in a property window
            Rect buttonPosition = new Rect(position.x + position.width - 20, position.y, 20, position.height);
            if (GUI.Button(buttonPosition, "O"))
            {
                if (currentIndex >= 0 && currentIndex < themeObjects.Length)
                {
                    // Open the Scriptable Object in a property window
                    EditorGUIUtility.PingObject(themeObjects[currentIndex]);
                }
            }

            EditorGUI.EndProperty();
        }
    }
}
