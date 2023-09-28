#if UNITY_EDITOR
using System;
using UnityEngine;

namespace ThemedUITool
{
    [Serializable]
    public class AddShadow
    {
        public bool addShadow = false;
        public Vector2 shadowOffset = new Vector2(1,-1);
        public Color shadowColor = new Color(0,0,0,0.5f);
    }
}
#endif