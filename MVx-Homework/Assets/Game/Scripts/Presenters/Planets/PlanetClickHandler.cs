using System;
using Modules.Planets;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetClickHandler : IInitializable, IDisposable
    {
        public event Action<PlanetPresenter> OnPlanetIncomeGathered;

        private readonly IPlanetPresenterService _planetPresenterService;


        public PlanetClickHandler(IPlanetPresenterService planetPresenterService)
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
                
                var presenter = _planetPresenterService.GetPlanetPresenter(planet);
                OnPlanetIncomeGathered?.Invoke(presenter);
            }
        }


        public void Dispose()
        {
            _planetPresenterService.OnPlanetClicked -= OnPlanetClickedHandler;
        }
    }
}