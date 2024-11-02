using System;
using UnityEngine;

namespace Patterns.Facade.Services
{
    public interface IInputService
    {
        event Action<Vector2> OnInput;
    }
}