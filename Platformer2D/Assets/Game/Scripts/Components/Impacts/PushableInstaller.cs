using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PushableInstaller : Installer<Rigidbody2D, PushableBody, PushableInstaller>
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly PushableBody _body;
        public PushableInstaller(Rigidbody2D rigidbody, PushableBody body)
        {
            _rigidbody = rigidbody;
            _body = body;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PushableComponent>()
                     .AsSingle()
                     .WithArguments(_rigidbody);
            
            Container.Bind<IPushableBody>()
                     .To<PushableBody>()
                     .FromInstance(_body)
                     .AsSingle();
        }
    }
}