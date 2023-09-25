using UnityEditor;

namespace ThemeUI
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TThemeSelector), true)]
    public class TThemeSelectorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            TThemeSelector themeSelector = (TThemeSelector)target;
            //if (themeSelector.theme == null)
            //{
            //    themeSelector.theme = ThemeUITool.GetAllThemes(typeof(TThemeSO)).FirstOrDefault();
            //}

            DrawPropertiesExcluding(serializedObject, "m_Script");

            if (themeSelector.Validate == true && themeSelector.m_ThemeTemp != null)
            {
                themeSelector.ApplyTheme();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}