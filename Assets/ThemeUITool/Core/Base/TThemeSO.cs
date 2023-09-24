#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEngine.Events;

namespace ThemeUITool
{
    public abstract class TThemeSO : ScriptableObject
    {
        public event UnityAction OnThemeChanged = () => { };
        [NonSerialized]public bool _themeChanged = false;

        public virtual void ThemeChanged()
        {
            _themeChanged = false;
            OnThemeChanged.Invoke();
        }
        private void OnValidate()
        {
            _themeChanged = true;
        }
    }
}
#endif