using UnityEngine;

namespace Patterns.State.WeaponStates
{
    [CreateAssetMenu(fileName = "NewPistolState", menuName = "Gof/State/Pistol", order = 0)]
    public class PistolState : WeaponState
    {
        [SerializeField] private float speed;
        [SerializeField] private string someText;

        public override void Enter(GameObject go)
        {
            go.GetComponent<Animator>().enabled = true;
        }

        public override void Exit(GameObject go)
        {
            go.GetComponent<Animator>().enabled = false;
        }
    }
}