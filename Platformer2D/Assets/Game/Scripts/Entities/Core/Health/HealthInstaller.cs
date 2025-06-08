
using UnityEngine;
using Zenject;

namespace Game.Entities
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