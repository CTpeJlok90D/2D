using System;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public struct Story
    {
        [TextArea(3,10)]
        public string Text;
        public Sprite IntercolutorSprite;
    }
}
