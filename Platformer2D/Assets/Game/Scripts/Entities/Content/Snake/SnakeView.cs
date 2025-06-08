using Cysharp.Threading.Tasks;
using Game.Entities.VFX;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class SnakeView : MonoBehaviour
    {
        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        private IHealthComponent _healthComponent;

        [Inject]
        private void Construct(IHealthComponent healthComponent)
        {
            _healthComponent = healthComponent;
        }

        private void OnEnable()
        {
            _healthComponent.OnDeath += OnDeath;
            _healthComponent.OnHealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _healthComponent.OnDeath -= OnDeath;
            _healthComponent.OnHealthChanged -= OnHealthChanged;
        }

        private void OnDeath() => PlayDeath().Forget();

        private void OnHealthChanged(float healthValue) => ShowTakenDamage().Forget();

        private UniTask ShowTakenDamage() => blinkVFX.Play();

        private async UniTaskVoid PlayDeath()
        {
            await ShowTakenDamage();
            gameObject.SetActive(false);
        }
    }
}