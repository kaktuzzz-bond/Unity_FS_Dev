using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        [Title("Settings")]
        [SerializeField]
        private int health = 1;
        
        [Title("Sensors")]
        [SerializeField]
        private TriggerSensor hit;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(health, health);
            
            Container.Bind<ITriggerProxy>()
                     .FromInstance(hit)
                     .AsSingle();
        }
    }
}