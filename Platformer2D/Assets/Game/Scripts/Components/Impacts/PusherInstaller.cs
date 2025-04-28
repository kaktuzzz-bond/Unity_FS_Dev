using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherInstaller : Installer<Vector3, PusherInstaller>
    {
        private readonly Vector3 _force;

        public PusherInstaller(Vector3 force)
        {
            _force = force;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PusherComponent>()
                     .AsSingle()
                     .WithArguments(_force);
        }
    }
}