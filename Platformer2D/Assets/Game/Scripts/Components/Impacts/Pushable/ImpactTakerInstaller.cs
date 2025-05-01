using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pushable
{
    public class ImpactTakerInstaller: Installer<ImpactTakerData, ImpactTakerInstaller>
    {
        [Inject]
        private readonly ImpactTakerData _data;
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PushableBody>()
                     .FromInstance(_data.Body)
                     .AsSingle();
            
            Container.BindInterfacesTo<PushTaker>()
                     .AsSingle()
                     .WithArguments(_data.Rigidbody);
        }
    }
}