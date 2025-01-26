using Game.Scripts.Player;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game
{
    [CreateAssetMenu(fileName = "NewGameInstaller", menuName = "Game/New Game Installer", order = 0)]
    public class GameInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            PlayerInputInstaller.Install(Container);
        }
    }
}