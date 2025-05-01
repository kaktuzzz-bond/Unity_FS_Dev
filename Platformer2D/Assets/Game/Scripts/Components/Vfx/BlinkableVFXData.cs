using System;
using UnityEngine;

namespace Game.Scripts.Components.Vfx
{
    [Serializable]
    public class BlinkableVFXData
    {
        [field: SerializeField]
        public Color Color { get; private set; } = Color.white;

        [field: SerializeField]
        public SpriteRenderer Renderer { get; private set; }

        [field: SerializeField]
        public float Duration { get; private set; } = 1f;

        [field: SerializeField]
        public int Frequency { get; private set; } = 10;
    }
}