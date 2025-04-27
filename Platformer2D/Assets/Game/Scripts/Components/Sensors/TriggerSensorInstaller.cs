using Zenject;

namespace Game.Scripts.Components.Sensors
{
    public class TriggerSensorInstaller : Installer<ITriggerSensor, TriggerSensorInstaller>
    {
        private readonly ITriggerSensor _triggerSensor;

        public TriggerSensorInstaller(ITriggerSensor triggerSensor)
        {
            _triggerSensor = triggerSensor;
        }
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TriggerSensor>()
                     .FromInstance(_triggerSensor)
                     .AsSingle();
        }
    }
}