using Game.Scripts.Components.Movement.Flip;
using Game.Scripts.Components.Movement.Move;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class MoveInstaller : Installer<Rigidbody2D, Transform, MoveSettings, MoveInstaller>
    {
        private readonly Rigidbody2D _rigidbodyComponent;

        private readonly Transform _body;

        private readonly MoveSettings _moveSettings;


        public MoveInstaller(Rigidbody2D rigidbodyComponent, Transform body, MoveSettings moveSettings)
        {
            _rigidbodyComponent = rigidbodyComponent;
            _body = body;
            _moveSettings = moveSettings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FlipComponent>()
                     .AsSingle()
                     .WithArguments(_body);

            Container.BindInterfacesTo<MoveComponent>()
                     .AsSingle()
                     .WithArguments(_rigidbodyComponent, _moveSettings);
        }
    }
}