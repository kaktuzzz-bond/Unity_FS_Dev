using Modules.Inventories;

namespace SampleGame
{
    public sealed class ItemPopupShower
    {
        private readonly ItemPopup _popup;
        private readonly PresenterMock _presenter;

        public ItemPopupShower( PresenterMock presenter)
        {
            //_popup = popup;
            _presenter = presenter;
        }
        
        public void Show(InventoryItem item)
        {
            _presenter.SetItem(item);

            _popup.Show();
        }
    }
}