using UnityEngine;

namespace Game.Scripts.Components.Audio
{
    public class AudioComponent : IAudioComponent
    {
        private readonly AudioSource _source;

        public AudioComponent(AudioSource source)
        {
            _source = source;
        }

        public void Play(AudioClip clip)
        {
            _source.PlayOneShot(clip);
        }
    }
}