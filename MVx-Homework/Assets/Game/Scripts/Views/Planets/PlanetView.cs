using System;
using Game.Scripts.Views.Planets.Price;
using Game.Scripts.Views.Planets.Progressbar;
using Modules.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planets
{
    public class PlanetView : MonoBehaviour, IPlanetView
    {
        public event Action OnClick;
        public event Action OnHold;

        [SerializeField]
        private Image planetIcon;

        [SerializeField]
        private Image lockIcon;

        [SerializeField]
        private CoinView coinView;

        [SerializeField]
        private ProgressbarView progressbarView;

        [SerializeField]
        private PriceView priceView;

        [SerializeField]
        private SmartButton button;


        private void Awake()
        {
            ShowCoin(false);
            ShowProgressbar(false);
        }


        private void OnEnable()
        {
            button.OnClick += OnButtonClicked;
            button.OnHold += OnButtonHold;
        }


        private void OnButtonHold() =>
            OnHold?.Invoke();


        private void OnButtonClicked() =>
            OnClick?.Invoke();


        public void SetPlanetIcon(Sprite icon) =>
            planetIcon.sprite = icon;


        public void SetPrice(string price) =>
            priceView.SetText(price);


        public void ShowLockIcon(bool makeActive) =>
            lockIcon.gameObject.SetActive(makeActive);


        public void ShowCoin(bool makeActive) =>
            coinView.SetActive(makeActive);


        public void ShowProgressbar(bool makeActive) =>
            progressbarView.SetActive(makeActive);


        public void ShowPrice(bool makeActive) =>
            priceView.SetActive(makeActive);


        private void OnDisable()
        {
            button.OnClick -= OnButtonClicked;
            button.OnHold -= OnButtonHold;
        }
    }
}