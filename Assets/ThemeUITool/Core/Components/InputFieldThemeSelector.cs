using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    public class InputFieldThemeSelector : TThemeSelector<InputFieldThemeSO>
    {
        // Members
        [SerializeField] private TMP_InputField m_InputField;

        // Properties
        public TMP_InputField targetInputField { get => m_InputField; set => m_InputField = value; }

        protected private override void Apply()
        {
            if (m_Theme == null) m_Theme = Theme;

            if (m_InputField != null)
            {
                m_InputField.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

                ThemeUITool.SetImageTheme(m_InputField.targetGraphic.GetComponent<Image>(), m_Theme.fieldBackground, m_Theme.colorBlock.normalColor);
                ThemeUITool.SetTextTheme(m_InputField.textComponent.GetComponent<TMP_Text>(), m_Theme.textSize, m_Theme.fontAsset, m_Theme.fontColor);
                ThemeUITool.SetTextTheme(m_InputField.placeholder.GetComponent<TMP_Text>(), m_Theme.placeholderSize, m_Theme.placeholderAsset, m_Theme.placeholderColor);
                ThemeUITool.SetShadow(m_InputField.gameObject, m_Theme.addShadow.addShadow, m_Theme.addShadow.shadowOffset, m_Theme.addShadow.shadowColor);

                if (m_Theme.multiline.multiline && m_InputField.verticalScrollbar != null)
                {
                    m_InputField.verticalScrollbar.gameObject.SetActive(true);
                    ScrollbarThemeSelector scrollbarThemeSelector = m_InputField.verticalScrollbar.GetComponent<ScrollbarThemeSelector>();
                    scrollbarThemeSelector.Theme = m_Theme.multiline.profile;
                    if (scrollbarThemeSelector.Theme != null)
                    {
                        scrollbarThemeSelector.ApplyTheme();
                    }
                }
                if (!m_Theme.multiline.multiline && m_InputField.verticalScrollbar != null)
                {
                    m_InputField.verticalScrollbar.gameObject.SetActive(false);
                }
                    m_InputField.textViewport.GetComponent<RectMask2D>().padding = m_Theme.textAreaPadding;
                m_InputField.fontAsset = m_Theme.fontAsset;
                m_InputField.colors = m_Theme.colorBlock;
            }
        }
    }
}