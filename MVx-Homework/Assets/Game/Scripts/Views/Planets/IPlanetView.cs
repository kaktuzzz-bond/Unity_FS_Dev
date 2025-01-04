using System;
using UnityEngine;

namespace Game.Scripts.Views.Planets
{
    public interface IPlanetView
    {
        event Action OnClick;
        event Action OnHold;

        void SetIcon(Sprite icon);

        void ShowLockIcon(bool makeActive);

        void ShowCoin(bool makeActive);

        void ShowProgress(bool makeActive);

        void ShowPrice(bool makeActive);
    }
}