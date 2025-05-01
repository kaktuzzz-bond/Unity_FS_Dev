using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class MoveInstaller:Installer<MovementData, MoveInstaller>
    {
        [Inject]
        private readonly MovementData _data;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveUseCase>()
                     .AsCached()
                     .WithArguments(_data.Rigidbody, _data.Body, _data.Speed, _data.IsFlippable);
        }
    }
}