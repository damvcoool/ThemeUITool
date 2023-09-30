#if UNITY_EDITOR

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{

    [AddComponentMenu("Theme UI Tool/Scroll Rect Theme Selector", 5)]
    public class ScrollRectThemeSelector : TThemeSelector<ScrollRectThemeSO>
    {
        // Members
        [SerializeField] private ScrollRect m_ScrollRect;
        [SerializeField] private Image m_Background;

        //// Properties
        public ScrollRect targetScrollRect { get => m_ScrollRect; set => m_ScrollRect = value; }
        public Image background { get => m_Background; set => m_Background = value; }

        protected private override void Apply()
        {
            if (m_Theme == null) m_Theme = Theme;

            if (m_ScrollRect == null || m_Background == null) WarningEmptyFields();

            if (m_ScrollRect != null)
            {
                m_ScrollRect.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

                ThemeUITool.SetImageTheme(m_Background,m_Theme.background, m_Theme.backgroundColor);
                ThemeUITool.SetImageTheme(m_ScrollRect.viewport.GetComponent<Image>(), m_Theme.viewportMask, m_Theme.viewportMaskColor);

                m_ScrollRect.horizontal = m_Theme.enableHorizontal;
                m_ScrollRect.vertical = m_Theme.enableVertical;

                m_ScrollRect.movementType = m_Theme.contentMovement;

                m_ScrollRect.horizontalScrollbarVisibility = m_Theme.horizontalVisibility;
                m_ScrollRect.verticalScrollbarVisibility = m_Theme.verticalVisibility;

                m_ScrollRect.horizontalScrollbarSpacing = m_Theme.horizontalSpacing;
                m_ScrollRect.verticalScrollbarSpacing = m_Theme.verticalSpacing;

                if (m_ScrollRect.horizontalScrollbar != null && m_ScrollRect.horizontal)
                {
                    if (m_ScrollRect.horizontalScrollbar.GetComponent<ScrollbarThemeSelector>())
                    {
                        m_ScrollRect.horizontalScrollbar.GetComponent<ScrollbarThemeSelector>().Theme = m_Theme.horizontalProfile;
                    }
                    else
                    {
                        m_ScrollRect.horizontalScrollbar.gameObject.AddComponent<ScrollbarThemeSelector>();
                    }
                    m_ScrollRect.horizontalScrollbar.GetComponent<ScrollbarThemeSelector>().ApplyTheme();
                }

                if (m_ScrollRect.verticalScrollbar != null && m_ScrollRect.vertical)
                {
                    if (m_ScrollRect.verticalScrollbar.GetComponent<ScrollbarThemeSelector>())
                    {
                        m_ScrollRect.verticalScrollbar.GetComponent<ScrollbarThemeSelector>().Theme = m_Theme.verticalProfile;
                    }
                    else
                    {
                        m_ScrollRect.verticalScrollbar.gameObject.AddComponent<ScrollbarThemeSelector>();
                    }
                    m_ScrollRect.verticalScrollbar.GetComponent<ScrollbarThemeSelector>().ApplyTheme();
                }
            }
        }
    }
}
#endif