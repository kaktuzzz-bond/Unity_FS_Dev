using System;
using Loop;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject startScreen;

        private GameLoop _gameLoop;


        [Inject]
        private void Construct(GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            _gameLoop.OnGameStarted += Hide;
        }
        
        private void OnDestroy() =>
            _gameLoop.OnGameStarted -= Hide;


        private void Awake() =>
            Show();


        public void Hide() =>
            startScreen.SetActive(false);


        public void Show() =>
            startScreen.SetActive(true);
    }
}