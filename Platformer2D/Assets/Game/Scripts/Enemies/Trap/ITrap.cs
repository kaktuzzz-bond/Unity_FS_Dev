using System;
using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Health;


namespace Game.Scripts.Enemies.Trap
{
    public interface ITrap : IDamagable, IAttackable
    {
        public event Action OnDead; 
    }
}