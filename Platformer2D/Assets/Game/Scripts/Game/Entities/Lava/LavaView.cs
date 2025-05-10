using Game.Scripts.GameSystem.Audio;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Lava
{
    public class LavaView : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        private AudioProvider _audioProvider;


        [Inject]
        private void Construct(AudioProvider audioProvider)
        {
            _audioProvider = audioProvider;
        }

        public void PlayLava()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Lava));
        }
    }
}