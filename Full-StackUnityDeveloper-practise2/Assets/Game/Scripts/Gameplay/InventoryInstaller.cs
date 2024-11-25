using Modules.Inventories;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    //Нельзя менять!
    [CreateAssetMenu(
        fileName = "InventoryInstaller",
        menuName = "Gameplay/New InventoryInstaller"
    )]
    public sealed class InventoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private Inventory.Cell[] initialItems;
        
        public override void InstallBindings()
        {
            this.Container
                .Bind<Inventory>()
                .FromInstance(new Inventory(this.initialItems))
                .NonLazy();

            this.Container
                .BindInterfacesAndSelfTo<InventoryItemConsumer>()
                .AsSingle()
                .NonLazy();
            
            this.Container.BindInterfacesTo<PresenterMock>()
                .AsSingle()
                .WithArguments(initialItems[0].Item, "5")
                .NonLazy();
        }
    }
}