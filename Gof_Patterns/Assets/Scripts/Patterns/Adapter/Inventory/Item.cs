namespace Patterns.Adapter.Inventory
{
    public class Item
    {
        public string Name { get; }
        public int Capacity { get; }

        public Item(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}