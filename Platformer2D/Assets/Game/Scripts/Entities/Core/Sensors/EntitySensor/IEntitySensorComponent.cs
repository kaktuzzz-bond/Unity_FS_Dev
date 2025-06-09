using System;
using System.Collections.Generic;

namespace Game.Entities
{
    public interface IEntitySensorComponent
    {
        void ScanAndRun<T>(Action<T> callback) where T : class;

        IEnumerable<T> ScanFor<T>() where T : class;
        IEnumerable<T> Scan<T>() where T : class;
    }
}