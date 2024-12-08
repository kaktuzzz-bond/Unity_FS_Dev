using Gameplay.Management;
using Modules.Difficulty;
using Modules.Score;
using Modules.UI;
using UnityEngine;

namespace UI
{
    public class UIController : IGameStartedListener, IGameFinishedListener, IGameFailedListener, IGameWonListener
    {
        private readonly GameUI _gameUI;

        private readonly IDifficulty _difficulty;
        private readonly IScore _score;


        public UIController(GameUI gameUI, IDifficulty difficulty, IScore score)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
            _score = score;
        }


        public void OnGameStarted()
        {
            Debug.Log("UI: OnGameStarted");
            _difficulty.OnStateChanged += OnDifficultyChanged;
            _score.OnStateChanged += OnScoreChanged;

            ResetUIValues();
        }


        public void OnGameFinished()
        {
            Debug.Log("UI: OnGameFinished");
            _difficulty.OnStateChanged -= OnDifficultyChanged;
            _score.OnStateChanged -= OnScoreChanged;
        }


        public void OnGameFailed() => 
            _gameUI.GameOver(false);


        public void OnGameWon() => 
            _gameUI.GameOver(true);


        private void OnScoreChanged(int amount) => 
            _gameUI.SetScore(amount.ToString());


        private void OnDifficultyChanged() => 
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);


        private void ResetUIValues()
        {
            _ = _difficulty.Next(out var nextDifficulty);
            _gameUI.SetDifficulty(nextDifficulty, _difficulty.Max);
            _gameUI.SetScore(0.ToString());
        }
    }
}