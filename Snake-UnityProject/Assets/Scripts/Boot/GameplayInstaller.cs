using Gameplay.Management;
using Gameplay.Player;
using Gameplay.World;
using Input;
using Input.InputMaps;
using Modules.Coin;
using Modules.Snake;
using UnityEngine;
using Zenject;

namespace Boot
{
    [CreateAssetMenu(fileName = "NewGameplayInstaller", menuName = "Game/New Gameplay Installer")]
    public class GameplayInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private PlayerInputMap playerInputMap;

        [SerializeField]
        private Snake snakePrefab;

        [SerializeField]
        private Coin coinPrefab;

        [SerializeField]
        private int maxDifficulty = 5;


        public override void InstallBindings()
        {
            GameLoopInstaller.Install(Container);

            WorldInstaller.Install(Container, coinPrefab, maxDifficulty);

            InputInstaller.Install(Container, playerInputMap);

            PlayerInstaller.Install(Container, snakePrefab);
        }
    }
}