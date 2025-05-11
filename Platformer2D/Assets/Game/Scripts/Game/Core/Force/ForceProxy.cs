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
        

        public void AddForce(Vector2 force)
        {
            _forceComponent.AddForce(force);
        }
    }
}