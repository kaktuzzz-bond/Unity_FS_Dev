using Game.Scripts.Game.Core.Patrol;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Platform
{
    public class PlatformInstaller : MonoInstaller
    {
      
        [SerializeField, BoxGroup("Movement", ShowLabel = false)]
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