using System.Collections.Generic;
using UnityEngine;

namespace Game.GameSystem
{
    public class AudioProvider
    {
        private readonly IReadOnlyDictionary<SoundKey, AudioClip> _sounds;

        public AudioProvider(IReadOnlyDictionary<SoundKey, AudioClip> sounds)
        {
            _sounds = sounds;
        }

        public AudioClip GetClip(SoundKey key)
        {
            if (!_sounds.TryGetValue(key, out var clip))
            {
                Debug.LogError("AudioProvider error!");
            }

            return clip;
        }
    }
}