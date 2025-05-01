using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Sensors.GroundRaycast;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class CharacterJumpInstaller : Installer<GroundSensorData, JumpData, float, CharacterJumpInstaller>
    {
        [Inject]
        private readonly GroundSensorData _groundData;

        [Inject]
        private readonly JumpData _jumpData;

        [Inject]
        private readonly float _cooldown;


        public override void InstallBindings()
        {
            GroundSensorInstaller.Install(Container, _groundData);
            JumpInstaller.Install(Container, _jumpData);

            Container.BindInterfacesTo<CharacterJumper>()
                     .AsSingle()
                     .WithArguments(new CooldownTimer(_cooldown));
        }
    }
}