using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planets.Coin
{
    public class CoinView : MonoBehaviour, ICoinView
    {
        [SerializeField]
        private Image iconImage;


        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }


        public void Show()
        {
            gameObject.SetActive(true);
        }


        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}