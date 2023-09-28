using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New Toggle Theme", menuName = "Themed UI/Toggle Theme", order = 7)]
    public class ToggleThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 20f;

        [Header("Checkbox Properties")]
        [SerializeField] internal Sprite backgroundSprite = _Background;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;

        [Header("Checkmark Properties")]
        [SerializeField] internal Sprite checkmarkImage = _Checkmark;
        [SerializeField] internal Color checkmarkColor= Color.white;

        [Header("Label Properties")]
        [SerializeField] internal bool displayText = true;
        [SerializeField] internal float textSize = 14f;
        [SerializeField] internal TMP_FontAsset fontAsset = _FontAsset;
        [SerializeField] internal Color fontColor = new Color(0.2f, 0.2f, 0.2f);
    }
}