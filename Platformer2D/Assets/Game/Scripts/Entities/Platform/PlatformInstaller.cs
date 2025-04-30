using System.Linq;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Patrol;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Platform
{
    public class PlatformInstaller : MonoInstaller
    {
        [BoxGroup("Settings")]
        [SerializeField, BoxGroup("Settings/Movement")]
        private float movementSpeed = 1;

        [SerializeField, BoxGroup("Settings/Movement")]
        private bool isFlippable;

        [SerializeField]
        private Rigidbody2D rigidbodyComponent;

        [SerializeField]
        private Transform body;

        [SerializeField]
        private PlatformView view;

        [SerializeField]
        private Transform[] waypoints;


        public override void InstallBindings()
        {
            MoveInstaller.Install(Container, rigidbodyComponent, body, movementSpeed, isFlippable);
            PatrolInstaller.Install(Container, body, waypoints.Select(x => x.localPosition).ToList());

            EntityInstaller.Install(Container);

            Container.Bind<PlatformView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Platform>()
                     .AsSingle();
        }
    }
}