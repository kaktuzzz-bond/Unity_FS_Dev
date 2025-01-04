using System;
using UnityEngine;

namespace Game.Scripts.Views.Planets
{
    public interface IPlanetView
    {
        event Action OnClick;
        event Action OnHold;

        void SetIcon(Sprite icon);

        void ShowLockIcon(bool isVisible);

        void ShowCoin(bool isVisible);

        void ShowProgress(bool isVisible);

        void ShowPrice(bool isVisible);
    }
}