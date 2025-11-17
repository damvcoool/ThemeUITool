#if UNITY_EDITOR
using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace ThemedUITool
{
    /// <summary>
    /// Base class for all theme ScriptableObjects. Provides common functionality for theme management
    /// and event handling when theme properties change.
    /// </summary>
    public abstract class TThemeSO : ScriptableObject
    {
        internal static Sprite _UISprite;
        internal static Sprite _Background;
        internal static Sprite _UIMask;
        internal static Sprite _InputFieldBackground;
        internal static Sprite _Knob;
        internal static Sprite _Checkmark;
        internal static Sprite _DropdownArrow;
        internal static TMP_FontAsset _FontAsset;
        internal static ScrollbarThemeSO _hTheme;
        internal static ScrollbarThemeSO _vTheme;
        internal static ToggleThemeSO _templateToggle;
        internal static ScrollRectThemeSO _templateScrollRect;

        public event UnityAction OnThemeChanged = () => { };
        [NonSerialized] public bool _themeChanged = false;
        
        /// <summary>
        /// Invokes the OnThemeChanged event to notify all theme selectors that the theme has changed
        /// </summary>
        public virtual void ThemeChanged()
        {
            _themeChanged = false;
            OnThemeChanged.Invoke();
        }
        private void OnValidate()
        {
            _themeChanged = true;
        }
        private void OnEnable()
        {
            _UISprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            _Background = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
            _InputFieldBackground = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/InputFieldBackground.psd");
            _UIMask = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UIMask.psd");
            _Knob = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");
            _Checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Checkmark.psd");
            _DropdownArrow = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/DropdownArrow.psd");
            _FontAsset = TMP_Settings.defaultFontAsset;
            _hTheme = ThemeUITool.GetSpecificTheme<ScrollbarThemeSO>("DefaultHorizontalScrollbarTheme");
            _vTheme = ThemeUITool.GetSpecificTheme<ScrollbarThemeSO>("DefaultVerticalScrollbarTheme");
            _templateToggle = ThemeUITool.GetSpecificTheme<ToggleThemeSO>("DefaultTemplateToggle");
            _templateScrollRect = ThemeUITool.GetSpecificTheme<ScrollRectThemeSO>("DefaultTemplateScrolRect");
        }
    }
}
#endif