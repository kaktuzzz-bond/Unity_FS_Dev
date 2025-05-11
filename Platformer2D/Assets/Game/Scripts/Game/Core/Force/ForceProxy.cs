using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Core.Force
{
    public class ForceProxy : MonoBehaviour, IForceComponent
    {
        private IForceComponent _forceComponent;

        [Inject]
        private void Construct(IForceComponent forceComponent)
        {
            _forceComponent = forceComponent;
        }


        public event Action OnForceAdded;
        public Vector2 Position => _forceComponent.Position;

        public void AddForce(Vector2 force)
        {
            _forceComponent.AddForce(force);
        }

        public void AddForce(Vector2 force, Vector2 otherPosition)
        {
            _forceComponent.AddForce(force, otherPosition);
        }
    }
}