using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Health;
using Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        [SerializeField]
        private int health = 1;

        [SerializeField]
        private int attackDamage = 1;


        public override void InstallBindings()
        {
            //HealthInstaller.Install(Container, health);
            AttackInstaller.Install(Container, attackDamage);

            Container.Bind<ITrap>()
                     .To<Trap>()
                     .AsSingle();
        }
    }
}