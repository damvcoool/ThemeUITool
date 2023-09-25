using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    [CreateAssetMenu(fileName = "New Button Theme", menuName = "UI/Button Theme")]
    public class ButtonThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 30f;
        [SerializeField] internal bool addShadow = false;
        [SerializeField] internal Vector2 shadowOffset = new Vector2(1,-1);
        [SerializeField] internal Color shadowColor = new Color(0.1f, 0.1f, 0.1f);

        [Header("Button Properties")]
        [SerializeField] internal Sprite buttonImage;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;

        [Header("Text Properties")]
        [SerializeField] internal float textSize = 24f;
        [SerializeField] internal TMP_FontAsset fontAsset;
        [SerializeField] internal Color fontColor = new Color(0.2f, 0.2f, 0.2f);
    }
}