using Game.Scripts.Components.Movement.Move;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class MoveInstaller : Installer<Rigidbody2D, float, MoveInstaller>
    {
        private readonly Rigidbody2D _rigidbodyComponent;

        private readonly float _moveSpeed;


        public MoveInstaller(Rigidbody2D rigidbodyComponent, float moveSpeed)
        {
            _rigidbodyComponent = rigidbodyComponent;
            _moveSpeed = moveSpeed;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveComponent>()
                     .AsSingle()
                     .WithArguments(_rigidbodyComponent, _moveSpeed);
        }
    }
}