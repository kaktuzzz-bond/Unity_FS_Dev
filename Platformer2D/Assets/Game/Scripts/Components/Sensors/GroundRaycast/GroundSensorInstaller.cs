using Zenject;

namespace Game.Scripts.Components.Sensors.GroundRaycast
{
    public class GroundSensorInstaller : Installer<GroundSensorData, GroundSensorInstaller>
    {
        [Inject]
        private readonly GroundSensorData _data;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GroundRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_data.Origin, _data.LayerMask);
        }
    }
}