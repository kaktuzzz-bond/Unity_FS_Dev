using Patterns.FactoryMethod.Upgrades.Base;
using UnityEngine;

namespace Patterns.FactoryMethod.Upgrades.Attack
{
    public class AttackUpgrade : UpgradeBase
    {
        private readonly int _damage;

        public AttackUpgrade(string title, Sprite icon, int damage) : base(title, icon)
        {
            _damage = damage;
        }

        public override void Upgrade()
        {
            Debug.Log($"Attack upgrade {Title} : {_damage} : {Icon} ");
        }
    }
}