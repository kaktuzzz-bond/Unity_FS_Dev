using Game.Scripts.Game.Core.Health;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Installers
{
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField, Min(0)]
        public int maxHealth = 1;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(maxHealth);
        }
    }
}