using System;
using UnityEngine;

namespace Game.Scripts.Views.Planets
{
    public interface IPlanetView
    {
        event Action OnClick;
        event Action OnHold;
        Vector3 CoinPosition { get; }

        void SetPlanetIcon(Sprite icon);

        void SetPrice(string price);

        void SetProgress(float progress, string text);

        void ShowLockIcon(bool makeActive);

        void ShowCoin(bool makeActive);

        void ShowProgressbar(bool makeActive);

        void ShowPrice(bool makeActive);
    }
}