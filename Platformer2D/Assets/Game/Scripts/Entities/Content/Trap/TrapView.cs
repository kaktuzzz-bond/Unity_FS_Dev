using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class TrapView : MonoBehaviour
    {
        private IHealthComponent _healthComponent;

        [Inject]
        private void Construct(IHealthComponent healthComponent)
        {
            _healthComponent = healthComponent;
        }


        private void OnEnable() => _healthComponent.OnDeath += PlayDeath;


        private void OnDisable() => _healthComponent.OnDeath -= PlayDeath;

        public void PlayDeath() => gameObject.SetActive(false);
    }
}