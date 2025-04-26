using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.Components.Cooldown
{
    public class CooldownTimer : IDisposable
    {
        private readonly float _duration;

        public bool IsInProgress { get; private set; }

        private readonly CancellationTokenSource _cts = new();

        public CooldownTimer(float duration)
        {
            _duration = duration;
        }

        public void Launch() => LaunchAsync().Forget();

        private async UniTaskVoid LaunchAsync()
        {
            IsInProgress = true;

            await UniTask.WaitForSeconds(_duration);
            
            IsInProgress = false;
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}