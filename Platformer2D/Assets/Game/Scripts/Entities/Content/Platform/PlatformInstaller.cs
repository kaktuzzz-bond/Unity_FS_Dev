using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("Patrol", ShowLabel = false)]
        private PatrolComponent patrolComponent;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Platform>()
                     .AsSingle();

            Container.BindInterfacesTo<PatrolComponent>()
                     .FromInstance(patrolComponent)
                     .AsSingle();
        }
    }
}