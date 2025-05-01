using Game.Scripts.Components.Health;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Spider
{
    public class SpiderInstaller : MonoInstaller
    {
        [SerializeField]
        private HealthData healthData;
        
        public override void InstallBindings()
        {
          
            HealthInstaller.Install(Container,healthData);
        }
    }
}