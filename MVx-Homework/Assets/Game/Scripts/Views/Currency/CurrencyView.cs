using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Currency
{
    public class CurrencyView : MonoBehaviour, ICurrencyView
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TMP_Text currencyText;


        public void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }


        public void SetText(string text)
        {
            currencyText.text = text;
        }
    }
}