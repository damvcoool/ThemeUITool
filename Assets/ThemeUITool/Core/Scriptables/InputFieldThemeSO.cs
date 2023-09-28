using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New Input Field Theme", menuName = "Themed UI/Input Field Theme", order = 3)]
    public class InputFieldThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 30f;
        [SerializeField] internal AddShadow addShadow;
        
        [Header("Input Properties")]
        [SerializeField] internal Sprite fieldBackground = _InputFieldBackground;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;
        [SerializeField, Vector4Labels("Left", "Right", "Top", "Bottom")] internal Vector4 textAreaPadding = new Vector4(-8f,-8f, -5f, -5f);
        [SerializeField] internal UseMultiline multiline;

        [Header("Text Properties")]
        [SerializeField] internal float textSize = 14f;
        [SerializeField] internal TMP_FontAsset fontAsset = _FontAsset;
        [SerializeField] internal Color fontColor = new Color(0.2f, 0.2f, 0.2f);

        [Header("Placeholder Properties")]
        [SerializeField] internal float placeholderSize = 14f;
        [SerializeField] internal TMP_FontAsset placeholderAsset = _FontAsset;
        [SerializeField] internal Color placeholderColor = new Color(0.2f, 0.2f, 0.2f, 0.5f);

    }
}