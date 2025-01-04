using System;
using Game.Scripts.Views.Planets.Coin;
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


        private void OnEnable()
        {
            button.OnClick += OnButtonClicked;
            button.OnHold += OnButtonHold;
        }


        private void OnButtonHold() => 
            OnHold?.Invoke();


        private void OnButtonClicked() => 
            OnClick?.Invoke();


        public void SetIcon(Sprite icon)
        {
            planetIcon.sprite = icon;
        }


        public void ShowLockIcon(bool isVisible)
        {
            lockIcon.gameObject.SetActive(isVisible);
        }


        public void ShowCoin(bool isVisible)
        {
            if (isVisible)
                coinView.Show();
            else
                coinView.Hide();
        }


        public void ShowProgress(bool isVisible)
        {
            if (isVisible)
                progressbarView.Show();
            else
                progressbarView.Hide();
        }


        public void ShowPrice(bool isVisible)
        {
            if (isVisible)
                priceView.Show();
            else
                priceView.Hide();
        }


        private void OnDisable()
        {
            button.OnClick -= OnButtonClicked;
            button.OnHold -= OnButtonHold;
        }
    }
}