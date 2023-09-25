#if UNITY_EDITOR

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    public class ButtonThemeSelector : TThemeSelector
    {
        // Members
        [SerializeField] private ButtonThemeSO m_Theme;
        [SerializeField] private Button m_Button;
        [SerializeField] private TMP_Text m_ButtonText;

        // Properties
        public Button targetButton { get => m_Button; set => m_Button = value; }
        public TMP_Text buttonText { get => m_ButtonText; set => m_ButtonText = value; }

        protected override void Apply()
        {
            if (m_Theme == null) m_Theme = (ButtonThemeSO)m_ThemeTemp;

            if (m_Button != null) m_Button.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

            SetImageTheme(m_Button.image, m_Theme.buttonImage, m_Theme.colorBlock.normalColor);
            SetTextTheme(m_ButtonText, m_Theme.textSize, m_Theme.fontAsset, m_Theme.fontColor);
            SetShadow(m_Button.gameObject, m_Theme.addShadow, m_Theme.shadowOffset, m_Theme.shadowColor);

            m_Button.colors = m_Theme.colorBlock;
        }
    }
}
#endif