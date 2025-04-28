using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components
{
    public class PlatformComponent : ITickable
    {
        private readonly Transform _target;
        private readonly PatrolSettings _settings;


        private readonly IReadOnlyList<Vector3> _points;

        private const float Threshold = 0.001f;

        private int _currentIndex;

        public PlatformComponent(Transform target, PatrolSettings settings)
        {
            _target = target;
            _settings = settings;
            _points = _settings.Points;
        }

        private int CurrentIndex
        {
            get => _currentIndex;
            set => _currentIndex = value >= _points.Count ? 0 : value;
        }

        public void Tick()
        {
            if (_settings.Points.Count == 0) return;

            _target.transform.position = Vector3.Lerp(_target.transform.position, _points[CurrentIndex],
                _settings.PatrolSpeed * Time.deltaTime);

            if (Vector3.Distance(_target.transform.position, _points[_currentIndex]) <= Threshold)
            {
                CurrentIndex++;
            }
        }
    }


    [Serializable]
    public class PatrolSettings
    {
        [SerializeField]
        private float patrolSpeed = 1f;

        [SerializeField]
        private Transform[] points;

        public float PatrolSpeed => patrolSpeed;
        public IReadOnlyList<Vector3> Points => points.Select(x => x.position).ToList();
    }
}