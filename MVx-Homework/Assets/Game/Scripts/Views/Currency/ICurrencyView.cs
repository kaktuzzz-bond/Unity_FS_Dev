using UnityEngine;

namespace Game.Scripts.Views.Currency
{
    public interface ICurrencyView
    {
        void SetIcon(Sprite sprite);

        void SetText(string text);
    }
}