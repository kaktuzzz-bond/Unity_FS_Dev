using System;
using Modules.Planets;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetClickListener : IInitializable, IDisposable
    {
        private readonly IPlanetPresenterService _planetPresenterService;


        public PlanetClickListener(IPlanetPresenterService planetPresenterService)
        {
            _planetPresenterService = planetPresenterService;
        }


        public void Initialize()
        {
            _planetPresenterService.OnPlanetClicked += OnPlanetClickedHandler;
        }


        private void OnPlanetClickedHandler(IPlanet planet)
        {
            if (!planet.IsUnlocked && planet.CanUnlock)
            {
                planet.Unlock();

                return;
            }

            if (planet.IsIncomeReady)
            {
                planet.GatherIncome();
            }
        }


        public void Dispose()
        {
            _planetPresenterService.OnPlanetClicked -= OnPlanetClickedHandler;
        }
    }
}