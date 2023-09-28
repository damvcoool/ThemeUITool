using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomPropertyDrawer(typeof(AddShadow))]
    public class AddShadowDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // Calculate the height needed for your custom property field
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float verticalSpacing = 2f; // Adjust this value to change the vertical spacing
            float totalHeight = lineHeight + verticalSpacing; // Single line with spacing

            // If addShadow is true, add extra height for shadowOffset and shadowColor fields
            SerializedProperty addShadowProperty = property.FindPropertyRelative("addShadow");
            if (addShadowProperty != null && addShadowProperty.boolValue)
            {
                totalHeight += 2 * (lineHeight + verticalSpacing); // Two lines with spacing for shadowOffset and shadowColor
            }

            return totalHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Calculate the height needed for your custom property field
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float verticalSpacing = 2f; // Adjust this value to change the vertical spacing

            // Define rect for addShadow field
            Rect addShadowRect = new Rect(position.x, position.y, position.width, lineHeight);

            // Display addShadow field
            EditorGUI.PropertyField(addShadowRect, property.FindPropertyRelative("addShadow"), new GUIContent("Add Shadow"));

            // Check if addShadow is true
            SerializedProperty addShadowProperty = property.FindPropertyRelative("addShadow");
            if (addShadowProperty != null && addShadowProperty.boolValue)
            {
                // Define rects for shadowOffset and shadowColor fields
                Rect shadowOffsetRect = new Rect(position.x, position.y + lineHeight + verticalSpacing, position.width, lineHeight);
                Rect shadowColorRect = new Rect(position.x, position.y + 2 * (lineHeight + verticalSpacing), position.width, lineHeight);

                // Display shadowOffset and shadowColor fields
                EditorGUI.PropertyField(shadowOffsetRect, property.FindPropertyRelative("shadowOffset"));
                EditorGUI.PropertyField(shadowColorRect, property.FindPropertyRelative("shadowColor"));
            }

            EditorGUI.EndProperty();
        }
    }
}
