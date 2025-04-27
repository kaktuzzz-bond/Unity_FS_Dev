using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Audio
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