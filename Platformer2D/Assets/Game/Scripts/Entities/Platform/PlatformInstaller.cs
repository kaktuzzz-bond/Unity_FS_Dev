using System.Linq;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Movement;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Platform
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField]
        private MoveSettings moveSettings;
        
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
           MoveInstaller.Install(Container, rigidbodyComponent, body, moveSettings);
           PatrolInstaller.Install(Container, body,  waypoints.Select(x => x.localPosition).ToList());
           EntityInstaller.Install(Container);

           Container.Bind<PlatformView>()
                    .FromInstance(view)
                    .AsSingle();
           
           Container.BindInterfacesAndSelfTo<Platform>()
                    .AsSingle();
        }
    }
}