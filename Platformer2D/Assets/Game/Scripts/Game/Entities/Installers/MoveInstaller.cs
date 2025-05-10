using Game.Scripts.Game.Core.Movement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Installers
{
    public class MoveInstaller : MonoInstaller
    {
        [SerializeField]
        public new Rigidbody2D rigidbody;

        [SerializeField]
        public Transform body;

        [SerializeField]
        public float speed = 5;

        [SerializeField]
        public bool isFlippable = true;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveComponent>()
                     .AsCached()
                     .WithArguments(rigidbody, body, speed, isFlippable);
        }
    }
}