#if UNITY_EDITOR

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    [AddComponentMenu("Theme UI Tool/Scrollbar Theme Selector", 4)]
    public class ScrollbarThemeSelector : TThemeSelector<ScrollbarThemeSO>
    {
        // Members
        [SerializeField] private Scrollbar m_Scrollbar;
        [SerializeField] private Image m_Background;

        // Properties
        public Scrollbar targetScrollbar { get => m_Scrollbar; set => m_Scrollbar = value; }
        public Image scrollbarBackground { get => m_Background; set => m_Background = value; }

        protected private override void Apply()
        {
            if (m_Theme == null & Theme != null) m_Theme = Theme;

            if (m_Scrollbar == null || m_Background == null) WarningEmptyFields();

            if (m_Scrollbar != null)
            {
                m_Scrollbar.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

                ThemeUITool.SetImageTheme(m_Background, m_Theme.backgroundSprite, m_Theme.backgroundColor);
                ThemeUITool.SetImageTheme(m_Scrollbar.handleRect.GetComponent<Image>(), m_Theme.handleSprite, m_Theme.colorBlock.normalColor);
                m_Scrollbar.size = m_Theme.handleSize;
                m_Scrollbar.direction = m_Theme.direction;

                m_Scrollbar.colors = m_Theme.colorBlock;
            }
        }
    }
}
#endif