using System;
using UnityEngine;

namespace Converter
{
    public class Timer
    {
        public event Action OnTimeUp;

        private readonly float _seconds;
        private float _timer;


        public Timer(float seconds, bool autoStart = true)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException(nameof(seconds),
                                                      $"Was [{seconds}] : the value must be greater than or equal to 0.");

            _seconds = seconds;

            _timer = autoStart ? 0 : _seconds;
        }


        public void Tick(float deltaTime)
        {
            if (deltaTime < 0)
                throw new ArgumentOutOfRangeException(nameof(deltaTime),
                                                      $"[{deltaTime}] : the value must be greater than or equal to 0.");

            _timer -= deltaTime;

            if (_timer > 0f) return;

            OnTimeUp?.Invoke();

            Reset();
        }


        public void Reset()
        {
            _timer = _seconds;
        }
    }
}