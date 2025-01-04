using Game.Scripts.Views.HUD;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView moneyView;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoneyView>()
                     .FromInstance(moneyView)
                     .AsCached();
        }
    }
}