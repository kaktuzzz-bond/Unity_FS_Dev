using Zenject;

namespace Game.Scripts.Game.Core.Sensors.GroundRaycast
{
    public class GroundSensorInstaller : Installer<GroundSensorData, GroundSensorInstaller>
    {
        [Inject]
        private readonly GroundSensorData _data;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GroundSensor>()
                     .AsSingle()
                     .WithArguments(_data.Origin, _data.LayerMask);
        }
    }
}