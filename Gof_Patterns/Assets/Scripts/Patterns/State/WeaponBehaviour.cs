using System.Collections.Generic;
using UnityEngine;

namespace Patterns.State
{
    public class WeaponBehaviour : MonoBehaviour, IWeaponListener
    {
        [SerializeField] private Dictionary<WeaponType, WeaponState> _states;
        private WeaponState _currentState;


        public void OnWeaponChanged(WeaponType weaponType)
        {
            _currentState?.Exit(gameObject);
            _states.TryGetValue(weaponType, out _currentState);
            _currentState?.Enter(gameObject);
        }
    }
}