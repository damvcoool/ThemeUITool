using UnityEngine;
using UnityEngine.UI;
    
namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New Slider Theme", menuName = "Themed UI/Slider Theme", order = 6)]
    public class SliderThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 20f;

        [Header("Handle Properties")]
        [SerializeField] internal Sprite handleSprite = _Knob;
        [SerializeField] internal float handleWith = 20;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;

        [Header("Fill Properties")]
        [SerializeField] internal Sprite fillSprite = _UISprite;
        [SerializeField] internal Color fillColor = Color.white;

        [Header("Background Properties")]
        [SerializeField] internal Sprite backgroundSprite = _Background;
        [SerializeField] internal Color backgroundColor = Color.white;
    }
}