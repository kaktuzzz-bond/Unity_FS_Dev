using UnityEngine;

namespace Z_Gameplay.Management
{
    public class PlayerStateObserver : MonoBehaviour
    {
        [SerializeField] private GameCycle gameCycle;
        [SerializeField] private PlayerService playerService;

        public void StartObserving()
        {
            //playerService.Player.OnDied += gameCycle.GameOver;
        }
        
        private void OnDestroy()
        {
            //playerService.Player.OnDied -= gameCycle.GameOver;
        }
    }
}