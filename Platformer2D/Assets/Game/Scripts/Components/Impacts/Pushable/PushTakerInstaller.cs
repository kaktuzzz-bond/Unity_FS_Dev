using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pushable
{
    public class PushTakerInstaller: Installer<Rigidbody2D, PushTakerInstaller>
    {
        private readonly Rigidbody2D _rigidbody;

        public PushTakerInstaller(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PushTaker>()
                     .AsSingle()
                     .WithArguments(_rigidbody);
        }
    }
}