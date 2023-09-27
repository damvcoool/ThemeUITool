using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemeUI
{
    [CreateAssetMenu(fileName = "New Input Field Theme", menuName = "Themed UI/Input Field Theme", order = 1)]
    public class InputFieldThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 30f;
        [SerializeField] internal bool addShadow = false;
        [SerializeField] internal Vector2 shadowOffset = new Vector2(1, -1);
        [SerializeField] internal Color shadowColor = new Color(0.1f, 0.1f, 0.1f);

        [Header("Input Properties")]
        [SerializeField] internal Sprite fieldBackground;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;
        [SerializeField] internal bool multiline = false;
        [SerializeField] internal ScrollbarThemeSO scrollbarProfile;

        [Header("Text Properties")]
        [SerializeField] internal float textSize = 24f;
        [SerializeField] internal TMP_FontAsset fontAsset;
        [SerializeField] internal Color fontColor = new Color(0.2f, 0.2f, 0.2f);

        [Header("Placeholder Properties")]
        [SerializeField] internal float placeholderSize = 24f;
        [SerializeField] internal TMP_FontAsset placeholderAsset;
        [SerializeField] internal Color placeholderColor = new Color(0.2f, 0.2f, 0.2f);

    }
}