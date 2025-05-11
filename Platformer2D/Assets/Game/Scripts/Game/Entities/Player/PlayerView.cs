using Cysharp.Threading.Tasks;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.VFX;
using Game.Scripts.GameSystem.Audio;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
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


        [Inject]
        private void Construct(AudioProvider audioProvider)
        {
            _audioProvider = audioProvider;
        }

        public UniTask ShowTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);
            audioSource.PlayOneShot(_audioProvider.GetClip(SoundKey.TakeDamage));

            return blinkVFX.Play();
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

        public async UniTaskVoid PlayDeath()
        {
            await ShowTakenDamage(0f);
            gameObject.SetActive(false);
        }
    }
}