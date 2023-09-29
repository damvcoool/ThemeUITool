#if UNITY_EDITOR
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{

    [AddComponentMenu("Theme UI Tool/Dropdown Theme Selector", 2)]
    public class DropdownThemeSelector : TThemeSelector<DropdownThemeSO>
    {
        private protected override void Apply()
        {
            WarningEmptyFields();
        }
    }
}
#endif