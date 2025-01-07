using System;
using Game.Scripts.Presenters.Planets;
using Game.Scripts.Presenters.Popups;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters
{
    public class UIDebug : MonoBehaviour
    {
        [Inject]
        [ShowInInspector]
        private PlanetPopupPresenter _planetPopupPresenter;

        [Inject]
        [ShowInInspector]
        private PlanetPresenterService _planetPresenterService;


        private void Awake()
        {
            _planetPresenterService.OnPlanetClicked += (p)=> Debug.Log($"Planet Clicked: {p.Name}");
            _planetPresenterService.OnPlanetHold += (p)=> Debug.Log($"Planet Hold: {p.Name}");
        }
    }
}