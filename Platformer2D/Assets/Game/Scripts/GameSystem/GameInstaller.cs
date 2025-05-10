using Game.Scripts.GameSystem.Controllers;
using Game.Scripts.GameSystem.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.GameSystem
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