using UnityEngine;

namespace Patterns.State.WeaponStates
{
    [CreateAssetMenu(fileName = "NewFistsState", menuName = "Gof/State/Fists", order = 0)]
    public class FistsState : WeaponState
    {
        [SerializeField] private float damage = 10;

        public override void Enter(GameObject go)
        {
        }

        public override void Exit(GameObject go)
        {
        }
    }
}