using UnityEngine;

namespace Patterns.State.WeaponStates
{
    [CreateAssetMenu(fileName = "NewMachineGunState", menuName = "Gof/State/MachineGun", order = 0)]
    public class MachineGunState : WeaponState
    {
        [SerializeField] private GameObject projectilePrefab;

        public override void Enter(GameObject go)
        {
        }

        public override void Exit(GameObject go)
        {
        }
    }
}