using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Patrol;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Platform
{
    public class PlatformInstaller : MonoInstaller
    {
      
        [SerializeField]
        private PatrolData patrolData;


        public override void InstallBindings()
        {
            // MoveInstaller.Install(Container, movementData);
            // PatrolInstaller.Install(Container, patrolData);
            //
            // EntityInstaller.Install(Container);
            //
            // Container.BindInterfacesAndSelfTo<Platform>()
            //          .AsSingle();
        }
    }
}