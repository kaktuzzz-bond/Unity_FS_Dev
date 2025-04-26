using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Lava
{
    public class LavaView : MonoBehaviour
    {
        // [SerializeField]
        // private TriggerSensor triggerProxy;

        [Inject]
        private ILava _lava;

        private void OnEnable()
        {
            //triggerProxy.OnTriggered += OnTargetCaught;
        }

        private void OnTargetCaught(IDamagable target)
        {
            _lava.Attack(target);
        }

        private void OnDisable()
        {
            //triggerProxy.OnTriggered -= OnTargetCaught;
        }
    }
}