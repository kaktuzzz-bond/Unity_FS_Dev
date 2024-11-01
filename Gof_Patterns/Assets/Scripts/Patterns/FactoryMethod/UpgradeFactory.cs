using System.Collections.Generic;
using Patterns.FactoryMethod.Upgrades.Base;

namespace Patterns.FactoryMethod
{
    public class UpgradeFactory
    {
        private readonly UpgradeConfigBase[] _upgradeConfigs;

        public UpgradeFactory(UpgradeConfigBase[] upgradeConfigs)
        {
            _upgradeConfigs = upgradeConfigs;
        }

        public IEnumerable<UpgradeBase> Create()
        {
            foreach (var config in _upgradeConfigs)
            {
                yield return config.Create();
            }
        }
    }
}