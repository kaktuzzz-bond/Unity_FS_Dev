using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Game.Core.Patrol
{
    public class Patrol : IPatrolable
    {  [ShowInInspector]
        private readonly Transform _target;
        [ShowInInspector]
        private readonly IReadOnlyList<Vector3> _waypoints;
        
        private const float Threshold = 0.1f;

        private int _currentIndex;
        
        public Patrol(Transform target, IReadOnlyList<Vector3> waypoints)
        {
            _target = target;
            _waypoints = waypoints;
        }

        [ShowInInspector]
        public bool IsNear => Vector2.Distance(PointPos, LocalPos) <= Threshold;
        [ShowInInspector]
        public Vector3 Direction => (PointPos - LocalPos).normalized;
        [ShowInInspector]
        private Vector2 LocalPos => _target.transform.localPosition;
        [ShowInInspector]
        private Vector2 PointPos => _waypoints[_currentIndex];

        [Button]
        public void MoveNext()
        {
            var next = _currentIndex + 1;

            _currentIndex = next < _waypoints.Count ? next : 0;
        }
    }
}