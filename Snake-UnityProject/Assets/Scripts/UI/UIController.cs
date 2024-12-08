using System;
using Loop;
using Modules.Difficulty;
using Modules.Score;
using Modules.UI;
using UnityEngine;
using World;
using Zenject;

namespace UI
{
    public class UIController : IInitializable, IDisposable
    {
        private readonly IGameUI _gameUI;
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;
        private readonly PlayerDeathObserver _playerDeathObserver;
        private readonly CoinCollector _coinCollector;


        public UIController(IGameUI gameUI,
                            IDifficulty difficulty,
                            IScore score,
                            PlayerDeathObserver playerDeathObserver,
                            CoinCollector coinCollector)
        {
            _gameUI = gameUI;
            _difficulty = difficulty;
            _score = score;
            _playerDeathObserver = playerDeathObserver;
            _coinCollector = coinCollector;
        }


        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
            _score.OnStateChanged += OnScoreChanged;
            _playerDeathObserver.OnDeath += ShowFailed;
            _coinCollector.OnGameWon += ShowWin;
            
            ResetUIValues();
        }


        private void OnScoreChanged(int amount)
        {
            _gameUI.SetScore(amount.ToString());
        }


        private void OnDifficultyChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }


        private void ShowFailed()
        {
            _gameUI.GameOver(false);
        }


        private void ShowWin()
        {
            _gameUI.GameOver(true);
        }


        private void ResetUIValues()
        {
            _ = _difficulty.Next(out var nextDifficulty);
            _gameUI.SetDifficulty(nextDifficulty, _difficulty.Max);
            _gameUI.SetScore(0.ToString());
        }


        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
            _score.OnStateChanged -= OnScoreChanged;
            _playerDeathObserver.OnDeath -= ShowFailed;
            _coinCollector.OnGameWon -= ShowWin;
        }
    }
}