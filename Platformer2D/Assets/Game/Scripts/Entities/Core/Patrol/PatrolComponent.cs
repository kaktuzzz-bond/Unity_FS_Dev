using System;
using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    [Serializable]
    public class PatrolComponent : IInitializable, ITickable, IPatrolComponent
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private Transform[] waypoints;

        [SerializeField, Min(0)]
        private float cooldownTime = 1f;

        [SerializeField]
        private MoveComponent moveComponent;

        private Vector2 TargetPos => target.transform.localPosition;

        private Vector2 PointPos => waypoints[_currentIndex].localPosition;

        private const float Threshold = 0.1f;

        [ShowInInspector, ReadOnly, HideInEditorMode]
        private int _currentIndex;

        [ShowInInspector, ReadOnly, HideInEditorMode]
        private Vector2 _currentDirection;

        private ICooldownTimer _cooldown;

        public void Initialize()
        {
            _cooldown = new CooldownTimer(cooldownTime);

            moveComponent.AddCondition(() => !_cooldown.IsInProgress);
        }

        public void Tick()
        {
            _currentDirection = (PointPos - TargetPos).normalized;

            moveComponent.Move(_currentDirection);

            if (Vector2.Distance(PointPos, TargetPos) <= Threshold)
            {
                SetNextPoint();
            }
        }

        public void Pause()
        {
            _cooldown.Launch();
        }

        private void SetNextPoint()
        {
            var next = _currentIndex + 1;

            _currentIndex = next < waypoints.Length ? next : 0;
        }

        public bool IsValid => moveComponent.IsValid;

        public void AddCondition(Func<bool> condition) => moveComponent.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => moveComponent.RemoveCondition(condition);
    }
}