using Game.Scripts.Player;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    [CreateAssetMenu(fileName = "NewGameInstaller", menuName = "Game/NewGameInstaller", order = 0)]
    public class GameInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            PlayerInputInstaller.Install(Container);
            
            PlayerInstaller.Install(Container);
        }
    }
}