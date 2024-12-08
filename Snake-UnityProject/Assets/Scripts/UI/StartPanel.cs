using Gameplay.Management;
using UnityEngine;

namespace UI
{
    public class StartPanel : MonoBehaviour, IGameStartedListener
    {
        [SerializeField]
        private GameObject startScreen;


        private void Awake() =>
            startScreen.SetActive(true);


        public void OnGameStarted() =>
            startScreen.SetActive(false);
    }
}