using System;
using Modules.Planets;

namespace Game.Scripts.Presenters.Planets
{
    public interface IPlanetPresenterService
    {
        event Action<IPlanet> OnPlanetClicked;
        event Action<IPlanet> OnPlanetHold;
        
        PlanetPresenter GetPlanetPresenter(IPlanet planet);
    }
}