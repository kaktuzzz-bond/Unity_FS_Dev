using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Components.Patrol
{
    [Serializable]
    public class PatrolData
    {
        [field: SerializeField]
        public Transform Body  { get; private set; }
        
        [SerializeField]
        private Transform[] waypoints;

        public IReadOnlyList<Vector3> Waypoints => waypoints.Select(x => x.localPosition).ToList();
    }
}