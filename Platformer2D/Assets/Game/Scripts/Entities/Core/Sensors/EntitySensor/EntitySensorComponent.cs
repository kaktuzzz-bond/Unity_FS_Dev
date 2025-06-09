using System;
using System.Collections.Generic;
using System.Linq;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    [Serializable]
    public class EntitySensorComponent : IEntitySensorComponent
    {
        [SerializeField]
        public Transform origin;

        [SerializeField]
        public Transform sensorPoint;

        [SerializeField, Min(0)]
        public float raycastDistance = 1;

        [SerializeField]
        public LayerMask layerMask;


        private RaycastHit2D[] _hits = new RaycastHit2D[8];


        public void ScanAndRun<T>(Action<T> callback) where T : class
        {
            var entities = Scan<IEntityProxy>().Select(x => x.Entity);

            foreach (var entity in entities)
            {
                if (!entity.TryGet<T>(out var component)) continue;
                callback?.Invoke(component);
            }
        }

        public IEnumerable<T> ScanFor<T>() where T : class
        {
            var entities = Scan<IEntityProxy>().Select(x => x.Entity);

            var components = new HashSet<T>();

            foreach (var entity in entities)
            {
                if (!entity.TryGet<T>(out var component)) continue;
                components.Add(component);
            }

            return components;
        }

        public IEnumerable<T> Scan<T>() where T : class
        {
            var direction = new Vector2(sensorPoint.position.x - origin.position.x, 0f).normalized;

            Debug.DrawRay(sensorPoint.position, direction * raycastDistance, Color.red, 0.5f);

            _ = Physics2D.RaycastNonAlloc(sensorPoint.position, direction, _hits, raycastDistance, layerMask);

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