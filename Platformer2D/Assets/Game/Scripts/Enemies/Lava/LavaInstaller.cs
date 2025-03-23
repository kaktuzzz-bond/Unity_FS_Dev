using Game.Scripts.Components.Installers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Lava
{
    public class LavaInstaller : MonoInstaller
    {
        [SerializeField]
        private int attackDamage = 1000;


        public override void InstallBindings()
        {
            AttackInstaller.Install(Container, attackDamage);

            Container.Bind<ILava>()
                     .To<Lava>()
                     .AsSingle();
        }
    }
}