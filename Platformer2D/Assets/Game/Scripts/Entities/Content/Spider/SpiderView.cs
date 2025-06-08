using Cysharp.Threading.Tasks;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class SpiderView : MonoBehaviour
    {
        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        private IEntity _entity;

        [Inject]
        private void Construct(IEntity entity)
        {
            _entity = entity;
            _entity.Get<IHealthComponent>().OnDeath += OnDeath;
            _entity.Get<IHealthComponent>().OnHealthChanged += OnHealthChanged;
        }


        private void OnDestroy()
        {
            _entity.Get<IHealthComponent>().OnDeath -= OnDeath;
            _entity.Get<IHealthComponent>().OnHealthChanged -= OnHealthChanged;
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