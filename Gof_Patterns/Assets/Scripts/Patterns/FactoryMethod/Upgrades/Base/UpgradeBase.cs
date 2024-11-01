using UnityEngine;

namespace Patterns.FactoryMethod.Upgrades.Base
{
    public abstract class UpgradeBase
    {
        private readonly string _title;
        public string Title { get; }
        public Sprite Icon { get; }

        protected UpgradeBase(string title, Sprite icon)
        {
            _title = title;
        }


        public abstract void Upgrade();
    }
}