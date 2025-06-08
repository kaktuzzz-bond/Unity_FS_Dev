
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class ForceProxy : MonoBehaviour, IPushable
    {
        private IForceComponent _forceComponent;

        [Inject]
        private void Construct(IForceComponent forceComponent)
        {
            _forceComponent = forceComponent;
        }
        
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