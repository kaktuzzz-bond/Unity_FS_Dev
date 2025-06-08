using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class AttackInstaller : MonoInstaller
    {
        [SerializeField, Min(0)]
        public int damage = 1;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AttackComponent>()
                     .AsSingle()
                     .WithArguments(damage);
        }
    }
}