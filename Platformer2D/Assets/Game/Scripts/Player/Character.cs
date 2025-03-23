using Game.Scripts.Components;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Vfx;
using Game.Scripts.Data;
using Game.Scripts.UI;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Character : MonoBehaviour, IDamagable
    {
        [ShowInInspector, HideInEditorMode]
        private IHealthComponent _healthComponent;

        private HealthBarView _healthBarView;
        private IVisualFX _blinkVFX;


        private ITriggerProxy _triggerProxy;


        [Inject]
        public void Construct(
            IHealthComponent healthComponent,
            HealthBarView healthBarView,
            [Inject(Id = NameProvider.Vfx.Blink)]
            IVisualFX blinkVFX,
            ITriggerProxy triggerProxy)
        {
            _healthComponent = healthComponent;
            _healthBarView = healthBarView;
            _blinkVFX = blinkVFX;
            _triggerProxy = triggerProxy;
        }

        public void OnEnable()
        {
            _triggerProxy.OnTriggered += (col) => Debug.Log($"{gameObject.name} entered to {col.GetType().Name}");
        }

        [Button, HideInEditorMode]
        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);

            var health = _healthComponent.Health;
            _healthBarView.SetValue(health);

            _blinkVFX.Play(() =>
            {
                if (health <= 0f) gameObject.SetActive(false);
            });
        }
    }
}