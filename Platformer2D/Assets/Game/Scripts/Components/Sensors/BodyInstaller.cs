using Zenject;

namespace Game.Scripts.Components.Sensors
{
    public class BodyInstaller: Installer<DamagableBody, BodyInstaller>
    {
        private readonly DamagableBody _damagableBody;

        public BodyInstaller(DamagableBody damagableBody)
        {
            _damagableBody = damagableBody;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DamagableBody>()
                     .FromInstance(_damagableBody)
                     .AsSingle();
        }
    }
}