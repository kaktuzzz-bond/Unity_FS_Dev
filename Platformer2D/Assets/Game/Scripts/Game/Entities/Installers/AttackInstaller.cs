using Game.Scripts.Game.Core.Attack;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Installers
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