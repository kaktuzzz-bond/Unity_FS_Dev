using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Patrol
{
    public class PatrolInstaller : Installer<PatrolData, PatrolInstaller>
    {
        [Inject]
        private readonly PatrolData _data;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Patrol>()
                     .AsSingle()
                     .WithArguments(_data.Body, _data.Waypoints);
        }
    }
}