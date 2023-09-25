#if UNITY_EDITOR
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUITool
{
    [ExecuteAlways]
    public abstract class TThemeSelector : MonoBehaviour
    {
        //public virtual TThemeSO theme { get; set; }

        // Validate True is needed to apply the theme when it's changed.
        [NonSerialized] public bool Validate = false;

        protected virtual void OnValidate()
        {
            Validate = true;
        }
        protected virtual void Awake()
        {
            ApplyTheme();
        }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        public abstract void Register();
        public abstract void ApplyTheme();

        protected void SetShadow(GameObject target, bool addShadow, Vector2 shadowOffset, Color shadowColor)
        {
            Shadow shadow = target.GetComponent<Shadow>();
            if (addShadow)
            {
                if (shadow == null)
                {
                    shadow = target.AddComponent<Shadow>();
                }
                else
                {
                    shadow.enabled = true;

                }
                shadow.effectDistance = shadowOffset;
                shadow.effectColor = shadowColor;
            }
            else if (!addShadow && target.GetComponent<Shadow>() != null)
            {
                shadow.enabled = false;
            }
        }

        protected void SetTextTheme(TMP_Text target, float themeFontSize, TMP_FontAsset themeFont, Color themeColor)
        {
            if (target != null)
            {
                target.fontSize = themeFontSize;
                target.color = themeColor;
                if (themeFont != null)
                {
                    target.font = themeFont;
                }
            }
        }

        protected void SetImageTheme(Image target, Sprite themeSprite, Color themeColor, float? themeWith = null, float? themeHeight = null)
        {
            if (target != null)
            {
                target.sprite = themeSprite;
                target.color = themeColor;

                RectTransform rt = target.GetComponent<RectTransform>();

                float x = (themeWith != null) ? themeWith.Value : rt.sizeDelta.x;
                float y = (themeHeight != null) ? themeHeight.Value : rt.sizeDelta.y;
                                
                Vector2 wh = new Vector2(x, y);

                target.GetComponent<RectTransform>().sizeDelta = wh;

            }
        }
    }
}
#endif