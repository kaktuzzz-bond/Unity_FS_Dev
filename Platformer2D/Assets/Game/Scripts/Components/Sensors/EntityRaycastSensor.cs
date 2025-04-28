using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public class EntityRaycastSensor : IEntityRaycastSensor
    {
        private readonly Transform _origin;

        private readonly RaycastHit2D[] _hits;

        public EntityRaycastSensor(Transform origin, int arrayLength = 8)
        {
            _origin = origin;
            _hits = new RaycastHit2D[arrayLength];
        }


        public IEnumerable<Collider2D> Scan(Vector2 direction)
        {
            Debug.DrawRay(_origin.position, direction, Color.red, 0.5f);
            Physics2D.queriesHitTriggers = false;
            _ = Physics2D.RaycastNonAlloc(_origin.position, direction, _hits);

            return _hits
                   .Where(x => x.collider != null)
                   .Select(x => x.collider)
                   .ToList();
        }
    }
}