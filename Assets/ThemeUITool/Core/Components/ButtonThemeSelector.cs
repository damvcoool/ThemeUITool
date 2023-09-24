#if UNITY_EDITOR
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUITool
{
    public class ButtonThemeSelector : TThemeSelector
    {
        // Fields
        [SerializeField] public ButtonThemeSO m_Theme;
        [SerializeField] private Button m_Button;
        [SerializeField] private TMP_Text m_ButtonText;

        // Properties
        //public override TThemeSO Theme { get => m_theme; set => m_theme = (ButtonThemeSO)value; }
        public Button targetButton { get => m_Button; set => m_Button = value; }
        public TMP_Text buttonText { get => m_ButtonText; set => m_ButtonText = value; }

        public override void ApplyTheme()
        {
            base.ApplyTheme();
            Validate = false;

            if (m_Button == null || m_Theme == null)
                return;

            m_Button.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);

            SetImageTheme(m_Button.image, m_Theme.buttonImage, m_Theme.colorBlock.normalColor);
            SetTextTheme(m_ButtonText, m_Theme.textSize, m_Theme.fontAsset, m_Theme.fontColor);
            SetShadow(m_Button.gameObject, m_Theme.addShadow, m_Theme.shadowOffset, m_Theme.shadowColor);

        }
        public override void Register()
        {
            base.Register();
            if (m_Theme != null)
            {
                m_Theme.OnThemeChanged -= ApplyTheme;
                m_Theme.OnThemeChanged += ApplyTheme;
            }
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            if (m_Theme != null)
                m_Theme.OnThemeChanged += ApplyTheme;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            if (m_Theme != null)
                m_Theme.OnThemeChanged -= ApplyTheme;
        }
    }
}
#endif