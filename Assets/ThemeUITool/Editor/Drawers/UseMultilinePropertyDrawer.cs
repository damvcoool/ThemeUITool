using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomPropertyDrawer(typeof(UseMultiline))]
    public class UseMultilinePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Get the serialized properties for multiline and Profile
            SerializedProperty multilineProperty = property.FindPropertyRelative("multiline");
            SerializedProperty profileProperty = property.FindPropertyRelative("profile");

            // Calculate the position for the multiline property field
            Rect multilinePosition = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            // Draw the multiline property field
            EditorGUI.PropertyField(multilinePosition, multilineProperty, new GUIContent("Multiline"));

            // If multiline is true, calculate the position for the Profile field
            if (multilineProperty.boolValue)
            {
                // If 'multiline' is true and 'Profile' is null, assign a default value
                if (profileProperty.objectReferenceValue == null)
                    profileProperty.objectReferenceValue = ThemeUITool.GetSpecificTheme<ScrollbarThemeSO>("DefaultVerticalScrollbarTheme");

                Rect profilePosition = new Rect(
                    position.x,
                    position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
                    position.width,
                    EditorGUIUtility.singleLineHeight
                );

                // Draw the Profile field
                EditorGUI.PropertyField(profilePosition, profileProperty, new GUIContent("Profile"));
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUIUtility.singleLineHeight;

            SerializedProperty multilineProperty = property.FindPropertyRelative("multiline");

            // If multiline is true, add the height of the Profile field
            if (multilineProperty.boolValue)
            {
                totalHeight += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }

            return totalHeight;
        }
    }
}