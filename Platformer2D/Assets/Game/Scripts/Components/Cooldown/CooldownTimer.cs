using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Cooldown
{
    public class CooldownTimer : IDisposable, ICooldownTimer
    {
        private readonly float _duration;

        [ShowInInspector, ReadOnly]
        public bool IsInProgress { get; private set; }

        private readonly CancellationTokenSource _cts = new();

        public CooldownTimer(float duration)
        {
            _duration = duration;
        }

        public void Launch() => LaunchAsync().Forget();

        private async UniTaskVoid LaunchAsync()
        {
            Debug.Log($"Timer start: ({Time.time})  : ({this.GetHashCode()})");
            IsInProgress = true;

            await UniTask.WaitForSeconds(_duration, cancellationToken: _cts.Token);
            
            IsInProgress = false;
            Debug.Log($"Timer stop: ({Time.time})  : ({this.GetHashCode()})");
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}