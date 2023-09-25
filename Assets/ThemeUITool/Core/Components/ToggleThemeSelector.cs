#if UNITY_EDITOR

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    public class ToggleThemeSelector : TThemeSelector
    {
        // Fields
        [SerializeField] private ToggleThemeSO m_Theme;
        [SerializeField] private Toggle m_Toggle;
        [SerializeField] private TMP_Text m_Label;

        // Properties
        public Toggle targetToggle { get => m_Toggle; set => m_Toggle = value; }
        public TMP_Text sliderLabel { get => m_Label; set => m_Label = value; }

        protected override void Apply()
        {
            if (m_Theme == null & m_ThemeTemp != null) m_Theme = (ToggleThemeSO)m_ThemeTemp;

            if (m_Toggle != null) m_Toggle.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

            SetImageTheme(m_Toggle.targetGraphic.GetComponent<Image>(), m_Theme.backgroundSprite, m_Theme.colorBlock.normalColor);
            SetImageTheme(m_Toggle.graphic.GetComponent<Image>(), m_Theme.checkmarkImage, m_Theme.checkmarkColor);
            SetTextTheme(m_Label,m_Theme.textSize,m_Theme.fontAsset, m_Theme.fontColor);
            if(m_Theme.displayText) m_Label.enabled = true;
            else m_Label.enabled = false;
        }
    }
}
#endif