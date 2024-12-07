using Input;
using Input.InputMaps;
using Loop;
using Modules.Snake;
using Player;
using UnityEngine;
using World;
using Zenject;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "NewGameplayInstaller", menuName = "Game/New Gameplay Installer")]
    public class GameplayInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private PlayerInputMap playerInputMap;

        [SerializeField]
        private GameLoopMap gameLoopMap;

        [SerializeField]
        private Snake snakePrefab;


        public override void InstallBindings()
        {
            GameLoopInstaller.Install(Container);

            WorldInstaller.Install(Container);

            InputInstaller.Install(Container, playerInputMap, gameLoopMap);

            PlayerInstaller.Install(Container, snakePrefab);
        }
    }
}