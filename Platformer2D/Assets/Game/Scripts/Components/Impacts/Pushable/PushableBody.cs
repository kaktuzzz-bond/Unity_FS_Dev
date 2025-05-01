using System;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pushable
{
    [RequireComponent(typeof(Collider2D))]
    public class PushableBody : MonoBehaviour, IPushableBody
    {
        public Vector3 WorldPosition => transform.position;
        public event Action<Vector3> OnImpacted;

        public void TakePush(Vector3 force)
        {
            OnImpacted?.Invoke(force);
        }
    }
}