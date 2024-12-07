using Input.InputMaps;
using Player;
using Zenject;

namespace Input
{
    public class InputInstaller : Installer<PlayerInputMap, GameLoopMap, InputInstaller>
    {
        private readonly PlayerInputMap _playerInputMap;
        private readonly GameLoopMap _gameLoopMap;


        public InputInstaller(PlayerInputMap playerInputMap, GameLoopMap gameLoopMap)
        {
            _playerInputMap = playerInputMap;
            _gameLoopMap = gameLoopMap;
        }


        public override void InstallBindings()
        {
            Container.BindInstances(_playerInputMap,
                                    _gameLoopMap);

            Container.BindInterfacesAndSelfTo<PlayerInput>()
                     .AsSingle();
        }
    }
}