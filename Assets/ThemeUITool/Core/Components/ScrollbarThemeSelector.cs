#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    public class ScrollbarThemeSelector : TThemeSelector<ScrollbarThemeSO>
    {
        // Members
        //[SerializeField] private ScrollbarThemeSO m_Theme;
        [SerializeField] private Scrollbar m_Scrollbar;
        [SerializeField] private Image m_Background;

        // Properties
        //new public ScrollbarThemeSO Theme { get => m_Theme; set => m_Theme = value; }
        public Scrollbar targetScrollbar { get => m_Scrollbar; set => m_Scrollbar = value; }
        public Image scrollbarBackground { get => m_Background; set => m_Background = value; }

        protected private override void Apply()
        {
            if (m_Theme == null & Theme != null) m_Theme = Theme;

            if (m_Scrollbar != null)
            {
                m_Scrollbar.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

                ThemeUITool.SetImageTheme(m_Background, m_Theme.backgroundSprite, m_Theme.backgroundColor);
                ThemeUITool.SetImageTheme(m_Scrollbar.handleRect.GetComponent<Image>(), m_Theme.handleSprite, m_Theme.colorBlock.normalColor);
                m_Scrollbar.GetComponent<Scrollbar>().size = m_Theme.handleSize;

                m_Scrollbar.colors = m_Theme.colorBlock;
            }
        }
    }
}
#endif