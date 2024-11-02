using System;
using UnityEngine;

namespace Patterns.Facade
{
    public interface IFacade
    {
        event Action<Vector2> OnInput;
        int ClientId { get; }
        bool IsConnectedToNetwork { get; }
        void DoVeryUsefulThing();
    }
}