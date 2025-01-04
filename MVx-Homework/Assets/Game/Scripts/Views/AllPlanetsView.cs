using Modules.Planets;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views
{
    public class AllPlanetsView:MonoBehaviour
    {
        [Inject, ShowInInspector]
        public Planet[] _planets;
    }
}