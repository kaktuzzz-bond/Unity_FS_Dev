using System;

namespace Patterns.Prototype
{
    public class Item: ICloneableItem
    {
        private readonly string _name;
        private readonly float _speed;

        public Item(string name, float speed)
        {
            _name = name;
            _speed = speed;
        }

        //clones the single item
        public ICloneableItem Clone()
        {
            return new Item(_name, _speed);
        }
    }
}