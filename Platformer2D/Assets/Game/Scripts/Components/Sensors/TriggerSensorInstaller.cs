using Zenject;

namespace Game.Scripts.Components.Sensors
{
    public class TriggerSensorInstaller:Installer<ITriggerObserver, TriggerSensorInstaller>
    {

        private readonly ITriggerObserver _triggerObserver;

        public TriggerSensorInstaller(ITriggerObserver triggerObserver)
        {
            _triggerObserver = triggerObserver;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TriggerObserver>()
                     .FromInstance(_triggerObserver)
                     .AsSingle();
        }
    }
}