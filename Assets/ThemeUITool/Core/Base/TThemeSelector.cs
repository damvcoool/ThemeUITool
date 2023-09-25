#if UNITY_EDITOR
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    [ExecuteAlways]
    public abstract class TThemeSelector<T> : MonoBehaviour where T : TThemeSO
    {
        // Fields
        [SerializeField] private protected T m_Theme;
        
        // Properties
        public T theme { get; set; }

        // Validate True is needed to apply the theme when it's changed.
        [NonSerialized] public bool Validate = false;

        // Public Methods
        public virtual void ApplyTheme()
        {
            Validate = false;
            Register();
            Apply();
        }

        // Private Methods
        protected void OnValidate()
        {
            Validate = true;            
        }
        protected void OnEnable()
        {
            if (theme != null)
                theme.OnThemeChanged += ApplyTheme;
        }
        protected void OnDisable()
        {
            if (theme != null)
                theme.OnThemeChanged -= ApplyTheme;
        }
        protected void Awake()
        {
            theme = ThemeUITool.GetDefaultTheme<T>();
        }
        protected void Register()
        {
            if (theme != null)
            {
                theme.OnThemeChanged -= ApplyTheme;
                theme.OnThemeChanged += ApplyTheme;
            }
        }
        protected private abstract void Apply();
    }
}
#endif