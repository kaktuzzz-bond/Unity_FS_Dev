using UnityEngine;

namespace Game.Scripts.Components.Audio
{
    public interface IAudioComponent
    {
        void Play(AudioClip clip);
    }
}