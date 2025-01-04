using Modules.Planets;
using UnityEngine;

namespace Game.Scripts.Views.Planets.Factory
{
    public interface IPlanetViewFactory
    {
        IPlanetView Create(Vector3 at, string name);
    }
}