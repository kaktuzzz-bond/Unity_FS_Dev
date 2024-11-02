using System;
using UnityEngine;

namespace Patterns.Facade
{
    public class FakeFacade : IFacade
    {
        public event Action<Vector2> OnInput;
        public int ClientId => 12345;
        public bool IsConnectedToNetwork => true;
        
        public void DoVeryUsefulThing()
        {
            OnInput?.Invoke(Vector2.up);
        }
    }
}