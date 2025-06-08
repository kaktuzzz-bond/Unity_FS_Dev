using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class TrapView : MonoBehaviour
    {
        private IEntity _entity;

        [Inject]
        private void Construct(IEntity entity)
        {
            _entity = entity;
            _entity.Get<IHealthComponent>().OnDeath += PlayDeath;
        }

        private void OnDestroy() => _entity.Get<IHealthComponent>().OnDeath -= PlayDeath;

        private void PlayDeath() => gameObject.SetActive(false);
    }
}