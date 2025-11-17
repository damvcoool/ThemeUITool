#if UNITY_EDITOR
using System;
using UnityEngine;

namespace ThemedUITool
{
    /// <summary>
    /// Base class for all theme selector components. Automatically applies themes to UI elements
    /// and subscribes to theme change events for automatic updates.
    /// </summary>
    /// <typeparam name="T">The type of theme this selector uses</typeparam>
    [ExecuteAlways]
    public abstract class TThemeSelector<T> : MonoBehaviour where T : TThemeSO
    {
        // Fields
        [SerializeField] private protected T m_Theme;

        // Properties
        /// <summary>
        /// Gets or sets the theme asset used by this selector
        /// </summary>
        public virtual T Theme { get => m_Theme; set => m_Theme = value; }


        // Validate True is needed to apply the Theme when it's changed.
        [NonSerialized] public bool Validate = false;

        // Public Methods
        /// <summary>
        /// Applies the current theme to the UI element. This method is automatically called
        /// when the theme changes or when the component is validated.
        /// </summary>
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
            Debug.LogWarning($"One or more fields on the {GetType().Name} component are empty or have not been configured", this);
        }
        
        /// <summary>
        /// Abstract method that derived classes must implement to apply theme properties to their specific UI elements
        /// </summary>
        private protected abstract void Apply();
    }
}
#endif