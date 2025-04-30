using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pushable
{
    public class PushTakerInstaller: Installer<Rigidbody2D, IPushableBody, PushTakerInstaller>
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly IPushableBody _pushableBody;

        public PushTakerInstaller(Rigidbody2D rigidbody,  IPushableBody pushableBody)
        {
            _rigidbody = rigidbody;
            _pushableBody = pushableBody;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PushableBody>()
                     .FromInstance(_pushableBody)
                     .AsSingle();
            
            Container.BindInterfacesTo<PushTaker>()
                     .AsSingle()
                     .WithArguments(_rigidbody);
        }
    }
}