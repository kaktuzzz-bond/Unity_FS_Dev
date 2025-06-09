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

        private IEntity _entity;


        [Inject]
        private void Construct(IEntity entity)
        {
            _entity = entity;
            _entity.Get<Lava>().OnTriggered += PlayLava;
        }

        private void PlayLava()
        {
            audioSource.PlayOneShot(_entity.Get<AudioProvider>().GetClip(SoundKey.Lava));
        }

        private void OnDestroy()
        {
            _entity.Get<Lava>().OnTriggered -= PlayLava;
        }
    }
}