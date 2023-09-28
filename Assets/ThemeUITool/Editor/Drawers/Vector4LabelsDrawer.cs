using UnityEditor;
using UnityEngine;

namespace ThemedUITool
{
    [CustomPropertyDrawer(typeof(Vector4LabelsAttribute))]
    public class Vector4LabelsDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // Calculate the height needed for your custom property field
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float verticalSpacing = 2f; // Adjust this value to change the vertical spacing
            float totalHeight = (lineHeight + verticalSpacing); // Four components with spacing

            // If the property is expanded, add extra height for the labels
            if (property.isExpanded)
            {
                totalHeight += EditorGUIUtility.singleLineHeight * 4.5f; // 1 for the main label and 4 for field labels
            }

            return totalHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Get the custom attribute data
            Vector4LabelsAttribute vector4Labels = attribute as Vector4LabelsAttribute;

            if (property.propertyType == SerializedPropertyType.Vector4)
            {
                EditorGUI.BeginProperty(position, label, property);

                // Split the available height into four equal parts with additional spacing
                float lineHeight = EditorGUIUtility.singleLineHeight;
                float labelWidth = EditorGUIUtility.labelWidth;
                float verticalSpacing = 2f; // Adjust this value to change the vertical spacing
                float inputFieldWidth = (position.width - labelWidth);

                // Define rects for each component with adjusted width and spacing
                Rect xRect = new Rect(position.x, position.y + lineHeight + verticalSpacing, inputFieldWidth, lineHeight);
                Rect yRect = new Rect(position.x, position.y + 2 * (lineHeight + verticalSpacing), inputFieldWidth, lineHeight);
                Rect zRect = new Rect(position.x, position.y + 3 * (lineHeight + verticalSpacing), inputFieldWidth, lineHeight);
                Rect wRect = new Rect(position.x, position.y + 4 * (lineHeight + verticalSpacing), inputFieldWidth, lineHeight);

                // Display the main label and create a foldout header
                property.isExpanded = EditorGUI.BeginFoldoutHeaderGroup(position, property.isExpanded, label);
                EditorGUI.indentLevel++;

                // If the property is expanded, display field labels and input fields for each component
                if (property.isExpanded)
                {
                    EditorGUI.LabelField(xRect, vector4Labels.xLabel);
                    xRect.x += EditorGUIUtility.labelWidth;
                    EditorGUI.PropertyField(xRect, property.FindPropertyRelative("x"), GUIContent.none);

                    EditorGUI.LabelField(yRect, vector4Labels.yLabel);
                    yRect.x += EditorGUIUtility.labelWidth;
                    EditorGUI.PropertyField(yRect, property.FindPropertyRelative("y"), GUIContent.none);

                    EditorGUI.LabelField(zRect, vector4Labels.zLabel);
                    zRect.x += EditorGUIUtility.labelWidth;
                    EditorGUI.PropertyField(zRect, property.FindPropertyRelative("z"), GUIContent.none);

                    EditorGUI.LabelField(wRect, vector4Labels.wLabel);
                    wRect.x += EditorGUIUtility.labelWidth;
                    EditorGUI.PropertyField(wRect, property.FindPropertyRelative("w"), GUIContent.none);
                }

                EditorGUI.indentLevel--;
                EditorGUI.EndFoldoutHeaderGroup();

                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}