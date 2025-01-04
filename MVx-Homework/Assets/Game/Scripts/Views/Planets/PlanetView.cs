using Game.Scripts.Views.Planets.Coin;
using Game.Scripts.Views.Planets.Price;
using Game.Scripts.Views.Planets.Progressbar;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planets
{
    public class PlanetView : MonoBehaviour, IPlanetView
    {
        public event UnityAction OnClicked
        {
            add => button.onClick.AddListener(value);
            remove => button.onClick.RemoveListener(value);
        }

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
        private Button button;


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
    }
}