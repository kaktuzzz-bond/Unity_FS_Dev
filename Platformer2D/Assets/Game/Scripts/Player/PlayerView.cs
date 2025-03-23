using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Vfx;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        [SerializeField]
        private TriggerSensor triggerProxy;

        [Inject]
        private IPlayer _player;


        public void OnEnable()
        {
            _player.OnHealthChanged += AnimateDamage;
        }
        
        public void TakeDamage(int damage) => _player.TakeDamage(damage);
        
        private void AnimateDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);

            blinkVFX.Play(() =>
            {
                if (healthValue <= 0f) gameObject.SetActive(false);
            });
        }

        public void OnDisable()
        {
            _player.OnHealthChanged += AnimateDamage;
        }

      
    }
}