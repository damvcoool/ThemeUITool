using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThemedUITool
{
    [CreateAssetMenu(fileName = "New ScrollRect Theme", menuName = "Themed UI/ScrollRect Theme", order = 5)]
    public class ScrollRectThemeSO : TThemeSO
    {
        [Header("General Properties")]
        [SerializeField] internal float width = 200f;
        [SerializeField] internal float height = 200f;

        [Header("Content Properties")]
        [SerializeField] internal Sprite background = _Background;
        [SerializeField] internal Color backgroundColor = new Color (1,1,1,0.5f);
        [SerializeField] internal bool enableHorizontal = true;
        [SerializeField] internal bool enableVertical = true;
        [SerializeField] internal ScrollRect.MovementType contentMovement = ScrollRect.MovementType.Elastic;
        [SerializeField] internal bool useInertia = true;

        [Header("Horizontal Properties")]
        [SerializeField] internal ScrollbarThemeSO horizontalProfile = _hTheme;
        [SerializeField] internal ScrollRect.ScrollbarVisibility horizontalVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
        [SerializeField] internal float horizontalSpacing = -3f;
        
        [Header("Vertical Properties")]
        [SerializeField] internal ScrollbarThemeSO verticalProfile = _vTheme;
        [SerializeField] internal ScrollRect.ScrollbarVisibility verticalVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
        [SerializeField] internal float verticalSpacing = -3f;

    }
}
