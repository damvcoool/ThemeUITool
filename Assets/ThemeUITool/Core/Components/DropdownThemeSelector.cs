#if UNITY_EDITOR
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{

    [AddComponentMenu("Theme UI Tool/Dropdown Theme Selector", 2)]
    public class DropdownThemeSelector : TThemeSelector<DropdownThemeSO>
    {
        [SerializeField] private TMP_Dropdown m_Dropdown;
        [SerializeField] private Image m_Arrow;
        [SerializeField] private ToggleThemeSelector m_Item;
        private ScrollRectThemeSelector m_Template;

        // Properties
        public TMP_Dropdown TargetDropdown { get => m_Dropdown; set => m_Dropdown = value; }
        public Image Arrow { get => m_Arrow; set => m_Arrow = value; }
        public ToggleThemeSelector Item { get => m_Item; set => m_Item = value; }
        private protected override void Apply()
        {
            if (m_Theme == null) m_Theme = Theme;

            if (m_Dropdown == null || m_Arrow == null || m_Item == null) WarningEmptyFields();

            m_Dropdown.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Theme.width, m_Theme.height);
            ThemeUITool.SetImageTheme(m_Dropdown.image, m_Theme.dropdownImage, m_Theme.colorBlock.normalColor);
            ThemeUITool.SetImageTheme(m_Arrow, m_Theme.dropdownArrow, m_Theme.dropdownArrowColor);
            ThemeUITool.SetTextTheme(m_Dropdown.captionText, m_Theme.captionFontSize, m_Theme.captionFontAsset, m_Theme.captionFontColor);

            m_Item.Theme = m_Theme.templateItem;
            m_Template = m_Dropdown.template.GetComponent<ScrollRectThemeSelector>();
            m_Template.Theme= m_Theme.template;

            m_Template.ApplyTheme();
            m_Item.ApplyTheme();

            

        }
    }
}
#endif