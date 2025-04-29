using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class JumpInstaller: Installer<Rigidbody2D, float, float, JumpInstaller>
    {
        private readonly Rigidbody2D _rb;
        private readonly float _jumpHeight;
        private readonly float _fallGravityScale;

        public JumpInstaller(Rigidbody2D rb, float jumpHeight, float fallGravityScale)
        {
            _rb = rb;
            _jumpHeight = jumpHeight;
            _fallGravityScale = fallGravityScale;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JumpUseCase>()
                     .AsCached()
                     .WithArguments(_rb, _jumpHeight, _fallGravityScale);
        }
    }
}