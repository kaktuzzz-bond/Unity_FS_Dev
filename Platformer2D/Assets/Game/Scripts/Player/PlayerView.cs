using Game.Scripts.Components.Health;
using Game.Scripts.Components.Vfx;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        [SerializeField]
        private AudioClip takeDamageSound;
        
        [SerializeField]
        private AudioClip jumpSound;

        [SerializeField]
        private AudioClip tossSound;
        
        public void PlayTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);

            blinkVFX.Play(() =>
            {
                if (healthValue <= 0f) gameObject.SetActive(false);
            });
            
            audioSource.PlayOneShot(takeDamageSound);
        }

        public void PlayJump()
        {
            audioSource.PlayOneShot(jumpSound);
        }

        public void PlayToss()
        {
            audioSource.PlayOneShot(tossSound);
        }
    }
}