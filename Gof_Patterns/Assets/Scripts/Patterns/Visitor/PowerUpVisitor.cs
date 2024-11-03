using Patterns.Visitor.Components;
using UnityEngine;

namespace Patterns.Visitor
{
    [CreateAssetMenu(fileName = "NewPowerUpComponent", menuName = "Gof/Visitor/PowerUp", order = 0)]
    public class PowerUpVisitor : ScriptableObject, IVisitor
    {
        [SerializeField] private int speedMultiplier;
        [SerializeField] private int attackMultiplier;
        [SerializeField] private int healthMultiplier;
        public void Visit(MoveComponent moveComponent)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(AttackComponent attackComponent)
        {
            throw new System.NotImplementedException();
        }

        public void Visit(HealthComponent healthComponent)
        {
            throw new System.NotImplementedException();
        }
    }
}