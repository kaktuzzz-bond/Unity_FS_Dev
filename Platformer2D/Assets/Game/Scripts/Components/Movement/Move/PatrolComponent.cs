using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Movement.Move
{
    public class PatrolComponent : IPatrolComponent
    {
        [ShowInInspector, ReadOnly]
        private readonly Transform _target;

        [ShowInInspector, ReadOnly]
        private readonly IReadOnlyList<Vector3> _waypoints;

        [ShowInInspector, ReadOnly]
        public Vector3 Direction => (PointPos - LocalPos).normalized;

        [ShowInInspector, ReadOnly]
        public bool IsNear => Vector2.Distance(PointPos, LocalPos) <= Threshold;

        private const float Threshold = 0.01f;

        [ShowInInspector, ReadOnly]
        private int _currentIndex;

        private Vector2 LocalPos => _target.transform.localPosition;
        private Vector2 PointPos => _waypoints[_currentIndex];

        public PatrolComponent(Transform target, IReadOnlyList<Vector3> waypoints)
        {
            _target = target;
            _waypoints = waypoints;
        }

        public void MoveNext()
        {
            var next = _currentIndex + 1;

            _currentIndex = next < _waypoints.Count ? next : 0;
        }
    }
}