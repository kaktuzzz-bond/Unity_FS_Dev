using Modules.Extensions;
using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class CollisionDataComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        public int CollisionLayer => layerMask.LayerMaskToInt();
    }
}