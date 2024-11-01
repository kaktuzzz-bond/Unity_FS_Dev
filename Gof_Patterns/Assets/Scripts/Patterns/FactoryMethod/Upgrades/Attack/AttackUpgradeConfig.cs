using Patterns.FactoryMethod.Upgrades.Base;
using UnityEngine;

namespace Patterns.FactoryMethod.Upgrades.Attack
{
    [CreateAssetMenu(fileName = "NewAttackUpgradeConfig", menuName = "Gof/FactoryMethod/Attack", order = 0)]
    public class AttackUpgradeConfig : UpgradeConfigBase
    {
        [SerializeField] private int damage;

        public override UpgradeBase Create()
        {
            return new AttackUpgrade(title, icon, damage);
        }
    }
}