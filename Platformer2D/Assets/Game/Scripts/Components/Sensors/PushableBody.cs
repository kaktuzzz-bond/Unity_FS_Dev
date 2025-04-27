using System;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    [RequireComponent(typeof(Collider2D))]
    public class PushableBody : MonoBehaviour, IPushableBody
    {
        public event Action<Vector3> OnImpacted;

        public void TakePush(Vector3 force)
        {
            OnImpacted?.Invoke(force);
        }
    }
}