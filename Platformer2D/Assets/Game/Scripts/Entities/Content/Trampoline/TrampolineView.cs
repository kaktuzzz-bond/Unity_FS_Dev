using Game.GameSystem;
using Modules;
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
        private void Construct(IEntity entity)
        {
            _audioProvider = entity.Get<AudioProvider>();
        }

        public void PlayJump()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Trampoline));
        }
    }
}