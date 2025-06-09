using Cysharp.Threading.Tasks;
using Game.GameSystem;
using Game.UI;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private ParticleSystem pushVFX;

        [SerializeField]
        private ParticleSystem tossVFX;

        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        private IEntity _entity;

        [Inject]
        private void Construct(IEntity entity)
        {
            _entity = entity;

            _entity.Get<IHealthComponent>().OnDeath += OnDeath;
            _entity.Get<IHealthComponent>().OnHealthChanged += OnHealthChanged;
            _entity.Get<IJumpComponent>().OnJump += PlayJump;
            _entity.Get<IPushAdapter>().OnPush += PlayPush;
            _entity.Get<ITossAdapter>().OnToss += PlayToss;
        }


        private void OnDestroy()
        {
            _entity.Get<IHealthComponent>().OnDeath -= OnDeath;
            _entity.Get<IHealthComponent>().OnHealthChanged -= OnHealthChanged;
            _entity.Get<IJumpComponent>().OnJump -= PlayJump;
            _entity.Get<IPushAdapter>().OnPush -= PlayPush;
            _entity.Get<ITossAdapter>().OnToss -= PlayToss;
        }

        private void OnDeath() => PlayDeath().Forget();

        private void OnHealthChanged(float healthValue) => ShowTakenDamage(healthValue).Forget();

        private UniTask ShowTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);
            audioSource.PlayOneShot(_entity.Get<AudioProvider>().GetClip(SoundKey.TakeDamage));

            return blinkVFX.Play();
        }

        private async UniTaskVoid PlayDeath()
        {
            await ShowTakenDamage(0f);
            gameObject.SetActive(false);
        }

        private void PlayJump()
        {
            audioSource.PlayOneShot(_entity.Get<AudioProvider>().GetClip(SoundKey.Jump));
        }

        private void PlayPush()
        {
            audioSource.PlayOneShot(_entity.Get<AudioProvider>().GetClip(SoundKey.Push));
            pushVFX.Play();
        }

        private void PlayToss()
        {
            audioSource.PlayOneShot(_entity.Get<AudioProvider>().GetClip(SoundKey.Toss));
            tossVFX.Play();
        }
    }
}