using System;
using Game.Scripts.Game.Core.Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Core.Patrol
{
    [Serializable]
    public class PatrolComponent : MoveComponent, ITickable
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private Transform[] waypoints;

        // [ShowInInspector]
        private Vector2 TargetPos => target.transform.localPosition;

        // [ShowInInspector]
        private Vector2 PointPos => waypoints[_currentIndex].localPosition;


        private const float Threshold = 0.001f;

        [ShowInInspector, ReadOnly, HideInEditorMode]
        private int _currentIndex;

        [ShowInInspector, ReadOnly, HideInEditorMode]
        private Vector2 _currentDirection;

        public void Tick()
        {
            _currentDirection = (PointPos - TargetPos).normalized;

            Move(_currentDirection);

            if (Vector2.Distance(PointPos, TargetPos) <= Threshold)
            {
                SetNextPoint();
            }
        }

        private void SetNextPoint()
        {
            var next = _currentIndex + 1;

            _currentIndex = next < waypoints.Length ? next : 0;
        }
    }
}