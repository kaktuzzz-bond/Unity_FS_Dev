using Zenject;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class PusherInstaller : Installer<float, PusherInstaller>
    {
        private readonly float _pushForce;

        public PusherInstaller(float pushForce)
        {
            _pushForce = pushForce;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Pusher>()
                     .AsSingle()
                     .WithArguments(_pushForce);
        }
    }
}