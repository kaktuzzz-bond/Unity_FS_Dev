using Zenject;

namespace Game.Scripts.Components.Sensors.EntityRaycast
{
    public class EntitySensorInstaller : Installer<EntitySensorData, EntitySensorInstaller>
    {
        [Inject]
        private readonly EntitySensorData _data;
       
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EntityRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_data.Origin, _data.RaycastDistance, _data.LayerMask);
        }
    }
}