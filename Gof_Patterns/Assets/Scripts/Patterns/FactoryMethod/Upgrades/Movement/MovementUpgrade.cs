using Patterns.FactoryMethod.Upgrades.Base;
using UnityEngine;

namespace Patterns.FactoryMethod.Upgrades.Movement
{
    public class MovementUpgrade : UpgradeBase
    {
        private readonly float _speed;

        public MovementUpgrade(string title, Sprite icon, float speed) : base(title, icon)
        {
            _speed = speed;
        }

        public override void Upgrade()
        {
            Debug.Log($"Movement upgrade {Title} : {_speed} : {Icon} ");
        }
    }
}