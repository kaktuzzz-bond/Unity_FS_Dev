using UnityEngine;

namespace Game.Scripts.Game.Core.Audio
{
    public interface IAudioComponent
    {
        void Play(AudioClip clip);
    }
}