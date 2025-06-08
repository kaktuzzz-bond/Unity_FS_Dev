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

        private AudioProvider _audioProvider;
        private IEntity _entity;

        [Inject]
        private void Construct(AudioProvider audioProvider, IEntity entity)
        {
            _audioProvider = audioProvider;
            _entity = entity;

            _entity.Get<IHealthComponent>().OnDeath += OnDeath;
            _entity.Get<IHealthComponent>().OnHealthChanged += OnHealthChanged;
            _entity.Get<Player>().OnJump += PlayJump;
            _entity.Get<Player>().OnPush += PlayPush;
            _entity.Get<Player>().OnToss += PlayToss;
        }
        

        private void OnDeath() => PlayDeath().Forget();

        private void OnHealthChanged(float healthValue) => ShowTakenDamage(healthValue).Forget();

        private void OnDestroy()
        {
            _entity.Get<IHealthComponent>().OnDeath -= OnDeath;
            _entity.Get<IHealthComponent>().OnHealthChanged -= OnHealthChanged;
            _entity.Get<Player>().OnJump -= PlayJump;
            _entity.Get<Player>().OnPush -= PlayPush;
            _entity.Get<Player>().OnToss -= PlayToss;
        }

        private UniTask ShowTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.TakeDamage));

            return blinkVFX.Play();
        }

        private async UniTaskVoid PlayDeath()
        {
            await ShowTakenDamage(0f);
            gameObject.SetActive(false);
        }

        private void PlayJump()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Jump));
        }

        private void PlayPush()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Push));
            pushVFX.Play();
        }

        private void PlayToss()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Toss));
            tossVFX.Play();
        }
    }
}