using UnityEngine;

namespace Game.Scripts.Components.Health
{
    public class DeathUseCase : IMortal
    {
        private readonly GameObject _target;

        public DeathUseCase(GameObject target)
        {
            _target = target;
        }

        public void Die()
        {
            _target.SetActive(false);
        }
    }
}