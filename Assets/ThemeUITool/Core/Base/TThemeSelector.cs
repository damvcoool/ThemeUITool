#if UNITY_EDITOR
using System;
using UnityEngine;

namespace ThemeUI
{
    [ExecuteAlways]
    public abstract class TThemeSelector<T> : MonoBehaviour where T : TThemeSO
    {
        // Fields
        [SerializeField] private protected T m_Theme;
        
        // Properties
        public virtual T Theme { get; set; }


        // Validate True is needed to apply the Theme when it's changed.
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
            m_Theme.OnThemeChanged += ApplyTheme;
        }
        protected void OnDisable()
        {
            m_Theme.OnThemeChanged -= ApplyTheme;
        }
        protected void Awake()
        {
            if(m_Theme == null) m_Theme = ThemeUITool.GetDefaultTheme<T>();
        }
        protected void Register()
        {
            m_Theme.OnThemeChanged -= ApplyTheme;
            m_Theme.OnThemeChanged += ApplyTheme;
        }
        protected private abstract void Apply();
    }
}
#endif