using UnityEngine;

namespace Game.Scripts.Views.Planets.Coin
{
    public interface ICoinView
    {
        void SetIcon(Sprite icon);

        void Show();

        void Hide();
    }
}