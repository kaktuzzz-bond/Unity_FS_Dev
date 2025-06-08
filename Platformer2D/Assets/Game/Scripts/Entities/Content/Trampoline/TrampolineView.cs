using Game.GameSystem;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class TrampolineView : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        private AudioProvider _audioProvider;


        [Inject]
        private void Construct(AudioProvider audioProvider)
        {
            _audioProvider = audioProvider;
        }

        public void PlayJump()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Trampoline));
        }
    }
}