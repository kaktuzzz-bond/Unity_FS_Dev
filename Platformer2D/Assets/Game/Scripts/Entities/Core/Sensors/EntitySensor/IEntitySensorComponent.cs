using System.Collections.Generic;

namespace Game.Entities
{
    public interface IEntitySensorComponent
    {
        IEnumerable<T> Scan<T>() where T : class;
    }
}