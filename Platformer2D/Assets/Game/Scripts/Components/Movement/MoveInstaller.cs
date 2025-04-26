using Game.Scripts.Components.Movement.Move;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class MoveInstaller : Installer<Rigidbody2D, MoveSettings, MoveInstaller>
    {
        private readonly Rigidbody2D _rigidbodyComponent;

        private readonly MoveSettings _moveSettings;


        public MoveInstaller(Rigidbody2D rigidbodyComponent, MoveSettings moveSettings)
        {
            _rigidbodyComponent = rigidbodyComponent;
            _moveSettings = moveSettings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveComponent>()
                     .AsSingle()
                     .WithArguments(_rigidbodyComponent, _moveSettings.MoveSpeed);
        }
    }
}