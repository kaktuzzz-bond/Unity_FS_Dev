using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.EntityRaycast
{
    [Serializable]
    public class EntitySensor : IEntitySensor
    {
        [SerializeField]
        public Transform origin;

        [ SerializeField, Min(0)]
        public float raycastDistance = 1;

        [SerializeField]
        public LayerMask layerMask;

        private readonly RaycastHit2D[] _hits = new RaycastHit2D[8];

        

        public IEnumerable<T> Scan<T>(Vector2 direction) where T : class
        {
            Debug.DrawRay(origin.position, direction * raycastDistance, Color.red, 0.5f);

            Physics2D.queriesHitTriggers = false;
            
            _ = Physics2D.RaycastNonAlloc(origin.position, direction, _hits, raycastDistance, layerMask);

            var targets = new List<T>();

            foreach (var hit in _hits)
            {
                var collider = hit.collider;

                if (collider == null) continue;

                if (!collider.TryGetComponent<T>(out var target)) continue;

                targets.Add(target);
            }

            Array.Clear(_hits, 0, _hits.Length);

            return targets;
        }
    }
}