using UnityEngine;
using Zenject;

namespace Game.GameSystem
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