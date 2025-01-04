using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planets.Price
{
    public class PriceView : MonoBehaviour, IPriceView
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TMP_Text priceText;


        public void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }


        public void SetText(string text)
        {
            priceText.text = text;
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