using UnityEngine;
using UnityEngine.UI;
    
namespace ThemeUI
{
    [CreateAssetMenu(fileName = "New Slider Theme", menuName = "UI/Slider Theme")]
    public class SliderThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 20f;

        [Header("Handle Properties")]
        [SerializeField] internal Sprite handleSprite;
        [SerializeField] internal float handleWith = 20;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;

        [Header("Fill Properties")]
        [SerializeField] internal Sprite fillSprite;
        [SerializeField] internal Color fillColor = Color.white;

        [Header("Background Properties")]
        [SerializeField] internal Sprite backgroundSprite;
        [SerializeField] internal Color backgroundColor = Color.white;
    }
}