#if UNITY_EDITOR
using System;
using UnityEngine;

namespace ThemedUITool
{
    [ExecuteAlways]
    public abstract class TThemeSelector<T> : MonoBehaviour where T : TThemeSO
    {
        // Fields
        [SerializeField] private protected T m_Theme;

        // Properties
//        public virtual T Theme { get; set; }
        public virtual T Theme { get => m_Theme; set => m_Theme = value; }


        // Validate True is needed to apply the Theme when it's changed.
        [NonSerialized] public bool Validate = false;

        // Public Methods
        public virtual void ApplyTheme()
        {
            if (m_Theme == null)
            {
                Debug.LogWarning($"Theme is not assigned on {GetType().Name}", this);
                return;
            }
            
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
            if (m_Theme != null)
            {
                m_Theme.OnThemeChanged += ApplyTheme;
            }
        }
        protected void OnDisable()
        {
            if (m_Theme != null)
            {
                m_Theme.OnThemeChanged -= ApplyTheme;
            }
        }
        protected void Awake()
        {
            if (m_Theme == null) m_Theme = ThemeUITool.GetDefaultTheme<T>();
        }
        protected void Register()
        {
            if (m_Theme != null)
            {
                m_Theme.OnThemeChanged -= ApplyTheme;
                m_Theme.OnThemeChanged += ApplyTheme;
            }
        }

        protected void WarningEmptyFields()
        {
            Debug.LogWarning($"One or more fields on the {this.GetType().Name} component are empty has not been configured", this);
        }
        private protected abstract void Apply();
    }
}
#endif