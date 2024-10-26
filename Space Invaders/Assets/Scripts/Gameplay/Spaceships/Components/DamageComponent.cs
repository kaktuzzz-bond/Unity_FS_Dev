using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        public int Damage => damage;
    }
}