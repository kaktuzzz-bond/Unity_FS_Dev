using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Audio
{
    [Serializable]
    public class AudioComponent : IAudioComponent
    {
        [SerializeField]
        private AudioSource audioSource;


        public void Play(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}