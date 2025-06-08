using System;
using UnityEngine;

namespace Game.GameSystem
{
    [Serializable]
    public class AudioKeyValuePair
    {
        [SerializeField]
        private SoundKey key;

        [SerializeField]
        private AudioClip clip;

        public SoundKey Key => key;
        public AudioClip Clip => clip;
    }
}