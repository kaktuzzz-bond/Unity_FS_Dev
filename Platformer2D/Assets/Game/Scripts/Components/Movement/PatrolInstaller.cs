using System.Collections.Generic;
using Game.Scripts.Components.Movement.Move;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class PatrolInstaller : Installer<Transform, IReadOnlyList<Vector3>, PatrolInstaller>
    {
        private readonly Transform _target;
        private readonly IReadOnlyList<Vector3> _waypoints;
        
        public PatrolInstaller(Transform target, IReadOnlyList<Vector3> waypoints)
        {
            _target = target;
            _waypoints = waypoints;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PatrolComponent>()
                     .AsSingle()
                     .WithArguments(_target, _waypoints);
        }
    }
}