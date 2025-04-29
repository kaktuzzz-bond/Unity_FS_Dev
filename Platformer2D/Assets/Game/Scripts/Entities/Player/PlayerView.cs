using Game.Scripts.Components.Vfx;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        [SerializeField]
        private ParticleSystem pushVFX;
        
        [SerializeField]
        private ParticleSystem tossVFX;
        
        public void ShowTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);

            blinkVFX.Play(() =>
            {
                if (healthValue <= 0f) 
                    gameObject.SetActive(false);
            });
        }

        public void PlayPush() => pushVFX.Play();
        public void PlayToss() => tossVFX.Play();
    }
}