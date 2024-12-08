using Input;
using Input.InputMaps;
using Loop;
using Loop.GameEvents;
using Modules.Coin;
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
        
        [SerializeField]
        private Coin coinPrefab;

        [SerializeField]
        private int maxDifficulty = 5;

        public override void InstallBindings()
        {
            GameLoopInstaller.Install(Container, maxDifficulty);

            WorldInstaller.Install(Container, coinPrefab);

            InputInstaller.Install(Container, playerInputMap, gameLoopMap);

            PlayerInstaller.Install(Container, snakePrefab);
            
            GameEventInstaller.Install(Container);
        }
    }
}