using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Movement.Flip;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement.Move
{
    public class MoveComponent : IMoveComponent, IInitializable
    {
        private readonly Rigidbody2D _rb;
        private readonly IFlippable _flipComponent;
        private readonly MoveSettings _settings;
        private readonly ICondition _condition;


        public MoveComponent(Rigidbody2D rb, IFlippable flipComponent, MoveSettings settings)
        {
            _rb = rb;
            _flipComponent = flipComponent;
            _settings = settings;

            _condition = settings.Condition;
        }

        public void Initialize()
        {
            _rb.drag = _settings.Drag;
        }

        public void Move(Vector3 direction)
        {
            if (!_condition.IsValid) return;

            _rb.velocity = new Vector2(direction.x * _settings.MoveSpeed, _rb.velocity.y);

            if (!_settings.IsFlippable) return;
            
            _flipComponent.LookTowards(direction);
        }

        public void AddCondition(Func<bool> condition)
        {
            _condition.AddCondition(condition);
        }
    }
}