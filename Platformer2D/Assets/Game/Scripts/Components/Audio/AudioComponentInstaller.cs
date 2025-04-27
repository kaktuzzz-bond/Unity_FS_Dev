using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Audio
{
    public class AudioComponentInstaller : Installer<AudioSource, AudioComponentInstaller>
    {
        private readonly AudioSource _audioSource;

        public AudioComponentInstaller(AudioSource audioSource)
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