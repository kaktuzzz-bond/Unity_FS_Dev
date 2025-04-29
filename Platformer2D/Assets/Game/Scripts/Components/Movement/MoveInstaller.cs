using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class MoveInstaller:Installer<Rigidbody2D, Transform, float, bool, MoveInstaller>
    {
        private readonly Rigidbody2D _rb;
        private readonly Transform _body;
        private readonly float _speed;
        private readonly bool _isFlippable;

        public MoveInstaller(Rigidbody2D rb, Transform body, float speed, bool isFlippable)
        {
            _rb = rb;
            _body = body;
            _speed = speed;
            _isFlippable = isFlippable;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveUseCase>()
                     .AsCached()
                     .WithArguments(_rb, _body, _speed, _isFlippable);
        }
    }
}