using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class JumpInstaller: Installer<JumpData, JumpInstaller>
    {
        [Inject]
        private readonly JumpData _data;
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JumpUseCase>()
                     .AsCached()
                     .WithArguments(_data.Rigidbody, _data.Height, _data.FallGravityScale);
        }
    }
}