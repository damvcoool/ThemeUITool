#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    public class SliderThemeSelector : TThemeSelector
    {
        // Members
        [SerializeField] private SliderThemeSO m_Theme;
        [SerializeField] private Slider m_Slider;
        [SerializeField] private Image m_Background;

        // Properties
        public Slider targetSlider { get => m_Slider; set => m_Slider = value; }
        public Image sliderBackground { get => m_Background; set => m_Background = value; }

        protected override void Apply()
        {
            if (m_Theme == null & m_ThemeTemp != null) m_Theme = (SliderThemeSO)m_ThemeTemp;

            if (m_Slider != null) m_Slider.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);
            
            SetImageTheme(m_Background, m_Theme.backgroundSprite, m_Theme.backgroundColor);
            SetImageTheme(m_Slider.handleRect.GetComponent<Image>(), m_Theme.handleSprite, m_Theme.colorBlock.normalColor, m_Theme.handleWith);
            SetImageTheme(m_Slider.fillRect.GetComponent<Image>(), m_Theme.fillSprite, m_Theme.fillColor);

            m_Slider.colors = m_Theme.colorBlock;
        }
    }
}
#endif