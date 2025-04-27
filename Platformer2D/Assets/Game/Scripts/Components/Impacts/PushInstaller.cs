using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PushInstaller : Installer<Vector3, PushInstaller>
    {
        private readonly Vector3 _force;

        public PushInstaller(Vector3 force)
        {
            _force = force;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PushComponent>()
                     .AsSingle()
                     .WithArguments(_force);
        }
    }
}