using Game.Scripts.Components.Flip;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Installers
{
    public class FlipInstaller : Installer<Transform, FlipInstaller>
    {
        private readonly Transform _body;

        public FlipInstaller(Transform body)
        {
            _body = body;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FlipComponent>()
                     .AsSingle()
                     .WithArguments(_body);
        }
    }
}