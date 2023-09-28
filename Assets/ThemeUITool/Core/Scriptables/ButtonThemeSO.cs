using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New Button Theme", menuName = "Themed UI/Button Theme", order = 1)]
    public class ButtonThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 30f;
        [SerializeField] internal AddShadow addShadow;

        [Header("Button Properties")]
        [SerializeField] internal Sprite buttonImage = _UISprite;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;

        [Header("Text Properties")]
        [SerializeField] internal float textSize = 24f;
        [SerializeField] internal TMP_FontAsset fontAsset = _FontAsset;
        [SerializeField] internal Color fontColor = new Color(0.2f, 0.2f, 0.2f);
    }
}