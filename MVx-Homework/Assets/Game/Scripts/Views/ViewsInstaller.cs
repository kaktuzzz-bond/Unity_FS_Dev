using Game.Scripts.Views.Currency;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        private CurrencyView currencyView;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CurrencyView>()
                     .FromInstance(currencyView)
                     .AsCached();
        }
    }
}