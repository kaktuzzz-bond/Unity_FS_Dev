using Patterns.FactoryMethod.Upgrades.Base;
using UnityEngine;

namespace Patterns.FactoryMethod.Upgrades.Movement
{
    [CreateAssetMenu(fileName = "NewMovementUpgradeConfig", menuName = "Gof/FactoryMethod/Movement", order = 0)]
    public class MovementUpgradeConfig : UpgradeConfigBase
    {
        //private Character _character;
        [SerializeField] private float speed = 1.0f;
        public override UpgradeBase Create()
        {
            return new MovementUpgrade(title, icon, speed);
        }
    }
}