using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Components.Jump;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Cooldown
{
    public class CooldownTimer : IDisposable, ICooldownTimer
    {
        private readonly float _duration;

        [ShowInInspector]
        public bool IsInProgress { get; private set; }

        private readonly CancellationTokenSource _cts = new();

        public CooldownTimer(float duration)
        {
            _duration = duration;
        }

        public void Launch() => LaunchAsync().Forget();

        private async UniTaskVoid LaunchAsync()
        {
            Debug.Log($"Launch time ({Time.time})");
            IsInProgress = true;

            await UniTask.WaitForSeconds(_duration);
            
            IsInProgress = false;
            Debug.Log($"Stop time ({Time.time})");
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}