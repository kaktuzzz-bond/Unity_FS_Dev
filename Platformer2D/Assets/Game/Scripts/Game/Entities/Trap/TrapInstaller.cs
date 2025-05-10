using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.MonoComponents;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private TrapView view;

        [SerializeField, BoxGroup("Health", ShowLabel = false)]
        private HealthComponent healthComponent;

        [SerializeField, BoxGroup("Attack", ShowLabel = false)]
        private AttackComponent attackComponent;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private TriggerReceiver triggerReceiver;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.Bind<TrapView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Trap>()
                     .AsSingle();

            Container.BindInterfacesTo<HealthComponent>()
                     .FromInstance(healthComponent)
                     .AsSingle();

            Container.BindInterfacesTo<AttackComponent>()
                     .FromInstance(attackComponent)
                     .AsSingle();

            Container.BindInterfacesTo<TriggerReceiver>()
                     .FromInstance(triggerReceiver)
                     .AsSingle();
        }
    }
}