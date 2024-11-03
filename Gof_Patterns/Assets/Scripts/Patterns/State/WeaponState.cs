using System;
using UnityEngine;

namespace Patterns.State
{
    public abstract class WeaponState : ScriptableObject
    {
        public abstract void Enter(GameObject go);
        public abstract void Exit(GameObject gameObject);
    }
}