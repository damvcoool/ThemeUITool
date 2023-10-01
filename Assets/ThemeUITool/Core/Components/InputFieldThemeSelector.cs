#if UNITY_EDITOR

using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{

    [AddComponentMenu("Theme UI Tool/Input Field Theme Selector", 3)]
    public class InputFieldThemeSelector : TThemeSelector<InputFieldThemeSO>
    {
        // Members
        [SerializeField] private TMP_InputField m_InputField;

        // Properties
        public TMP_InputField TargetInputField { get => m_InputField; set => m_InputField = value; }

        protected private override async void Apply()
        {
            if (m_Theme == null) m_Theme = Theme;

            if (m_InputField == null) WarningEmptyFields();

            if (m_InputField != null)
            {
                m_InputField.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

                ThemeUITool.SetImageTheme(m_InputField.targetGraphic.GetComponent<Image>(), m_Theme.fieldBackground, m_Theme.colorBlock.normalColor);
                ThemeUITool.SetTextTheme(m_InputField.textComponent.GetComponent<TMP_Text>(), m_Theme.textSize, m_Theme.fontAsset, m_Theme.fontColor);
                ThemeUITool.SetTextTheme(m_InputField.placeholder.GetComponent<TMP_Text>(), m_Theme.placeholderSize, m_Theme.placeholderAsset, m_Theme.placeholderColor);
                ThemeUITool.SetShadow(m_InputField.gameObject, m_Theme.addShadow.addShadow, m_Theme.addShadow.shadowOffset, m_Theme.addShadow.shadowColor);

                m_InputField.textViewport.GetComponent<RectMask2D>().padding = m_Theme.textAreaPadding;
                m_InputField.fontAsset = m_Theme.fontAsset;
                m_InputField.colors = m_Theme.colorBlock;

                if (m_Theme.multiline.multiline)
                {
                    if (m_InputField.verticalScrollbar == null)
                    {
                        GameObject vScrl = ThemeUIToolCreator.CreateScrollbar();
                        vScrl.SetActive(false);
                        ThemeUITool.SetRectTransformProperties(vScrl, new Vector4(1, 0, 1, 1), new Vector2(20, 0), new Vector3(-10, 0, 0), m_InputField.gameObject);
                        m_InputField.verticalScrollbar = vScrl.GetComponent<Scrollbar>();
                    }

                    if (m_InputField.verticalScrollbar != null)
                    {
                        ScrollbarThemeSelector scrollbarThemeSelector = m_InputField.verticalScrollbar.GetComponent<ScrollbarThemeSelector>();
                        scrollbarThemeSelector.Theme = m_Theme.multiline.profile;

                        if (scrollbarThemeSelector.Theme != null)
                        {
                            scrollbarThemeSelector.ApplyTheme();
                        }
                    }
                    await Task.Delay(50);

                    m_InputField.verticalScrollbar.gameObject.SetActive(true);
                }

                if (!m_Theme.multiline.multiline && m_InputField.verticalScrollbar != null)
                {
                    m_InputField.verticalScrollbar.gameObject.SetActive(false);
                }
            }
        }
    }
}
#endif