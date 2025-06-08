using Cysharp.Threading.Tasks;
using Game.Entities.VFX;
using Game.GameSystem;
using Game.UI;
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
        private IHealthComponent _healthComponent;

        [Inject]
        private void Construct(AudioProvider audioProvider, IHealthComponent healthComponent)
        {
            _audioProvider = audioProvider;
            _healthComponent = healthComponent;
        }

        private void OnEnable()
        {
            _healthComponent.OnDeath += OnDeath;
            _healthComponent.OnHealthChanged += OnHealthChanged;
        }

        private void OnDeath() => PlayDeath().Forget();

        private void OnHealthChanged(float healthValue) => ShowTakenDamage(healthValue).Forget();

        private void OnDisable()
        {
            _healthComponent.OnDeath -= OnDeath;
            _healthComponent.OnHealthChanged -= OnHealthChanged;
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

        public void PlayJump()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Jump));
        }

        public void PlayPush()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Push));
            pushVFX.Play();
        }

        public void PlayToss()
        {
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.Toss));
            tossVFX.Play();
        }
    }
}