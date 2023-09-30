using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New Dropdown Theme", menuName = "Themed UI/Dropdown Theme", order = 2)]
    public class DropdownThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 30f;

        [Header("Dropdown Properties")]
        [SerializeField] internal Sprite dropdownImage = _UISprite;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;
        [SerializeField] internal float captionFontSize = 14;
        [SerializeField] internal Sprite drowpdownArrow = _DropdownArrow;
        [SerializeField] internal Color dropdownArrowColor = Color.white;

        [Header("Caption Text Properties")]
        [SerializeField] internal TMP_FontAsset captionFontAsset = _FontAsset;
        [SerializeField] internal Color captionFontColor = new Color(0.2f, 0.2f, 0.2f);

        [Header("Template Properties")]
        [SerializeField] internal ScrollRectThemeSO template = _templateScrollRect;
        [SerializeField] internal ToggleThemeSO templateItem = _templateToggle;
    }
}
