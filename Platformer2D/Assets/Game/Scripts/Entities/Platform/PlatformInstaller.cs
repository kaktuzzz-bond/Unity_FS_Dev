using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Patrol;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Platform
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField]
        private MovementData movementData;

        [SerializeField]
        private PatrolData patrolData;


        public override void InstallBindings()
        {
            MoveInstaller.Install(Container, movementData);
            PatrolInstaller.Install(Container, patrolData);

            EntityInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<Platform>()
                     .AsSingle();
        }
    }
}