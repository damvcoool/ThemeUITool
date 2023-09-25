using UnityEditor;

namespace ThemeUI
{
    [CustomEditor(typeof(TThemeSelector<>), true)]
    public class TThemeSelectorEditor<T> : Editor where T : TThemeSO
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            TThemeSelector<T> themeSelector = (TThemeSelector<T>)target;

            DrawPropertiesExcluding(serializedObject, "m_Script");

            if (themeSelector.Validate)
            {
                themeSelector.ApplyTheme();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
