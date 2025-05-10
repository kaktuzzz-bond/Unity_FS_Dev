using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Scripts.GameSystem.Audio
{
    [CreateAssetMenu(fileName = "AudioInstaller", menuName = "Zenject/Audio Installer", order = 0)]
    public class AudioInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private AudioKeyValuePair[] sounds;


        public override void InstallBindings()
        {
            Container.Bind<IReadOnlyDictionary<SoundKey, AudioClip>>()
                     .FromInstance(sounds.ToDictionary(p => p.Key, p => p.Clip))
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<AudioProvider>()
                     .AsSingle();
        }
    }
}