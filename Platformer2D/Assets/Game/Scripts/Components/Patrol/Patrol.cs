using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Components.Patrol
{
    public class Patrol : IPatrolable
    {
        private readonly Transform _target;

        private readonly IReadOnlyList<Vector3> _waypoints;


        private const float Threshold = 0.01f;

        private int _currentIndex;
        
        public Patrol(Transform target, IReadOnlyList<Vector3> waypoints)
        {
            _target = target;
            _waypoints = waypoints;
        }

        public bool IsNear => Vector2.Distance(PointPos, LocalPos) <= Threshold;
        public Vector3 Direction => (PointPos - LocalPos).normalized;
        private Vector2 LocalPos => _target.transform.localPosition;
        private Vector2 PointPos => _waypoints[_currentIndex];

        public void MoveNext()
        {
            var next = _currentIndex + 1;

            _currentIndex = next < _waypoints.Count ? next : 0;
        }
    }
}