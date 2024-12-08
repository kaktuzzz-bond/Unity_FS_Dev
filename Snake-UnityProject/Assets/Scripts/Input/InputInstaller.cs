using Input.InputMaps;
using Zenject;

namespace Input
{
    public class InputInstaller : Installer<PlayerInputMap, InputInstaller>
    {
        private readonly PlayerInputMap _playerInputMap;


        public InputInstaller(PlayerInputMap playerInputMap)
        {
            _playerInputMap = playerInputMap;
        }


        public override void InstallBindings()
        {
            Container.BindInstances(_playerInputMap);

            Container.BindInterfacesAndSelfTo<PlayerInput>()
                     .AsSingle();
        }
    }
}