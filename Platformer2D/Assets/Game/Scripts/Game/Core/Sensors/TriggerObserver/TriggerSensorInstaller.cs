using Zenject;

namespace Game.Scripts.Game.Core.Sensors.TriggerObserver
{
    public class TriggerSensorInstaller : Installer<TriggerObserverData, TriggerSensorInstaller>
    {
        [Inject]
        private readonly TriggerObserverData _data;
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TriggerObserver>()
                     .FromInstance(_data.TriggerObserver)
                     .AsSingle();
        }
    }
}