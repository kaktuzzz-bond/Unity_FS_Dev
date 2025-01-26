using UnityEngine;
using Zenject;

namespace Game.Scripts.Components
{
    public class CooldownComponent : ITickable
    {
        private readonly float _duration;
        private float _currentTime;

        public bool IsReady => _currentTime <= 0;

        public CooldownComponent(float duration, float currentTime = 0f)
        {
            _duration = duration;
            _currentTime = Mathf.Clamp(currentTime, 0f, _duration);
        }

        public void Reset() =>
            _currentTime = _duration;

        public void Tick()
        {
            if (IsReady) return;

            _currentTime -= Time.deltaTime;
        }
    }
}