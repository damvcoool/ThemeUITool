using UnityEditor;

namespace ThemeUITool
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TThemeSO), true)]
    public class TThemeSOEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, "m_Script");
            TThemeSO themeSO = (TThemeSO)target;
            if (themeSO._themeChanged)
            {
                themeSO.ThemeChanged();
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}