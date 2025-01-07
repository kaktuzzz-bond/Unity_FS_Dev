using System;
using UnityEngine;

namespace Game.Scripts.Views.Planets
{
    public interface IPlanetView
    {
        event Action OnClick;
        event Action OnHold;

        void SetPlanetIcon(Sprite icon);

        void SetPrice(string price);

        void ShowLockIcon(bool makeActive);

        void ShowCoin(bool makeActive);

        void ShowProgressbar(bool makeActive);
    }
}