namespace Patterns.Adapter.Craft
{
    public interface IInventoryAdapter
    {
        void AddItem(string itemName, int capacity);
        void RemoveItem(string itemName, int capacity);
    }
}