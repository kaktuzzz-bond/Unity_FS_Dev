using UnityEngine;

namespace Patterns.FactoryMethod.Upgrades.Base
{
    public abstract class UpgradeConfigBase : ScriptableObject
    {
        [SerializeField] protected string title;
        [SerializeField] protected Sprite icon;

        public abstract UpgradeBase Create();
    }
}