using Game.GameSystem;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class LavaView : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        private AudioProvider _audioProvider;
        private IEntity _entity;


        [Inject]
        private void Construct(AudioProvider audioProvider, IEntity entity)
        {
            _audioProvider = audioProvider;
            _entity = entity;
            _entity.Get<Lava>().OnTriggered += PlayLava;
        }

        private void PlayLava()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Lava));
        }

        private void OnDestroy()
        {
            _entity.Get<Lava>().OnTriggered -= PlayLava;
        }
    }
}