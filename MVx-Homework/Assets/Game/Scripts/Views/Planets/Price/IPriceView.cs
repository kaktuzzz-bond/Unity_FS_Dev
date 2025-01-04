using UnityEngine;

namespace Game.Scripts.Views.Planets.Price
{
    public interface IPriceView
    {
        void SetIcon(Sprite sprite);

        void SetText(string text);

        void Show();

        void Hide();
    }
}