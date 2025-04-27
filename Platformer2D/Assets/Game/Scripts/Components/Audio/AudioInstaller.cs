using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Audio
{
    public class AudioInstaller : Installer<AudioSource, AudioInstaller>
    {
        private readonly AudioSource _audioSource;

        public AudioInstaller(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AudioComponent>()
                     .AsSingle()
                     .WithArguments(_audioSource);
        }
    }
}