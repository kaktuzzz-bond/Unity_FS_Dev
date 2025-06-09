using System;
using Modules;
using Zenject;

namespace Game.Entities
{
    public class Trampoline : IInitializable, IDisposable
    {
        private readonly IEntity _entity;

        public Trampoline(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            _entity.Get<IEntityProxy>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(IEntity entity)
        {
            if (!entity.TryGet<IPushableComponent>(out var target)) return;

            _entity.Get<PushComponent>().Push(target);

            _entity.Get<TrampolineView>().PlayJump();
        }


        public void Dispose()
        {
            _entity.Get<IEntityProxy>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}