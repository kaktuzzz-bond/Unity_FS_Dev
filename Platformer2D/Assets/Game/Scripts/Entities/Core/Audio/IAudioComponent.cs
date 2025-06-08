using UnityEngine;

namespace Game.Entities
{
    public interface IAudioComponent
    {
        void Play(AudioClip clip);
    }
}