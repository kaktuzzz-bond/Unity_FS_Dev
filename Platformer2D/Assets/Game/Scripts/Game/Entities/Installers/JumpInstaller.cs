using Game.Scripts.Game.Core.Jump;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Installers
{
    public class JumpInstaller: MonoInstaller
    {
        [SerializeField]
        public new Rigidbody2D rigidbody;
        
        [ SerializeField]
        public float height = 5;

        [ SerializeField]
        public float fallGravityScale = 3;
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JumpComponent>()
                     .AsCached()
                     .WithArguments(rigidbody, height, fallGravityScale);
        }
    }
}