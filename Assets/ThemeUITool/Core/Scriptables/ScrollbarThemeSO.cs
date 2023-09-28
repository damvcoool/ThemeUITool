using UnityEngine;
using UnityEngine.UI;
    
namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New Scrollbar Theme", menuName = "Themed UI/Scrollbar Theme", order = 4)]
    public class ScrollbarThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 160f;
        [SerializeField] internal float height = 20f;

        [Header("Handle Properties")]
        [SerializeField] internal Sprite handleSprite = _UISprite;
        [SerializeField] internal ColorBlock colorBlock = ColorBlock.defaultColorBlock;
        [SerializeField] internal Scrollbar.Direction direction = Scrollbar.Direction.LeftToRight;
        [Range(0f, 1f), SerializeField] internal float handleSize = 0.2f;

        [Header("Background Properties")]
        [SerializeField] internal Sprite backgroundSprite = _Background;
        [SerializeField] internal Color backgroundColor = Color.white;
    }
}