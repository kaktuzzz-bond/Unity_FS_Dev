using System;
using Game.Scripts.Presenters.Planets;
using Zenject;


namespace Game.Scripts.Presenters.Popups


{
    public class PlanetPopupController : IInitializable, IDisposable
    {
        private readonly PopupShower _popupShower;
        private readonly IPlanetPresenterService _planetPresenterService;


        public PlanetPopupController(PopupShower popupShower,
                                    IPlanetPresenterService planetPresenterService)
        {
            _popupShower = popupShower;
            _planetPresenterService = planetPresenterService;
        }


        public void Initialize()
        {
            _planetPresenterService.OnPlanetHold += _popupShower.Show;
        }


        public void Dispose()
        {
            _planetPresenterService.OnPlanetHold -= _popupShower.Show;
        }
    }
}