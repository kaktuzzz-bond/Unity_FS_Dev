using System;
using Modules;
using Zenject;

namespace Game.Entities
{
    public class Lava : IInitializable, IDisposable
    {
        private readonly IEntity _entity;


        public Lava(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            _entity.Get<IEntityProxy>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(IEntity entity)
        {
            if (!entity.TryGet<IHealthComponent>(out var healthComponent)) return;

            _entity.Get<IAttackComponent>().Attack(healthComponent);
            _entity.Get<LavaView>().PlayLava();
        }


        public void Dispose()
        {
            _entity.Get<IEntityProxy>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}