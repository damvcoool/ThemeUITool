#if UNITY_EDITOR

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    public class ButtonThemeSelector : TThemeSelector<ButtonThemeSO>
    {
        // Members
        [SerializeField] private Button m_Button;
        [SerializeField] private TMP_Text m_ButtonText;

        // Properties
        public Button targetButton { get => m_Button; set => m_Button = value; }
        public TMP_Text buttonText { get => m_ButtonText; set => m_ButtonText = value; }

        protected private override void Apply()
        {
            if (m_Theme == null) m_Theme = theme;

            if (m_Button != null)
            {
                m_Button.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

                ThemeUITool.SetImageTheme(m_Button.image, m_Theme.buttonImage, m_Theme.colorBlock.normalColor);
                ThemeUITool.SetTextTheme(m_ButtonText, m_Theme.textSize, m_Theme.fontAsset, m_Theme.fontColor);
                ThemeUITool.SetShadow(m_Button.gameObject, m_Theme.addShadow, m_Theme.shadowOffset, m_Theme.shadowColor);

                m_Button.colors = m_Theme.colorBlock;
            }   
        }
    }
}
#endif