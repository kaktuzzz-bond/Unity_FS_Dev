using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public class EntityRaycastSensor : IEntityRaycastSensor
    {
        private readonly Transform _origin;
        private readonly float _raycastDistance;
        private readonly LayerMask _groundLayer;

        private readonly RaycastHit2D[] _hits = new RaycastHit2D[8];

        public EntityRaycastSensor(Transform origin, float raycastDistance, LayerMask groundLayer)
        {
            _origin = origin;
            _raycastDistance = raycastDistance;
            _groundLayer = groundLayer;
        }


        public IEnumerable<Collider2D> Scan(Vector2 direction)
        {
            Debug.DrawRay(_origin.position, direction * _raycastDistance, Color.red, 0.5f);

            Physics2D.queriesHitTriggers = false;
            _ = Physics2D.RaycastNonAlloc(_origin.position, direction, _hits, _raycastDistance, _groundLayer);

            var colliders = _hits
                            .Where(x => x.collider != null)
                            .Select(x => x.collider)
                            .ToList();

            Array.Clear(_hits, 0, _hits.Length);

            return colliders;
        }
    }
}