using UnityEngine;

namespace Game.Scripts.Death
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