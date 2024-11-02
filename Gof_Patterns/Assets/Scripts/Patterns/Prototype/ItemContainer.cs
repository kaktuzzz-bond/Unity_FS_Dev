using System.Collections.Generic;
using System.Linq;

namespace Patterns.Prototype
{
    public class ItemContainer : ICloneableItem
    {
        private readonly IEnumerable<ICloneableItem> _items;

        public ItemContainer(IEnumerable<ICloneableItem> items)
        {
            _items = items;
        }

        //clones the collection of items
        public ICloneableItem Clone()
        {
            var clones = _items
                .Select(i => i.Clone());

            return new ItemContainer(clones);
        }
    }
}