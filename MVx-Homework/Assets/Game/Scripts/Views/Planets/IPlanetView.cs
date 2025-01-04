using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Views.Planets
{
    public interface IPlanetView
    {
        event UnityAction OnClicked;

        void SetIcon(Sprite icon);

        void ShowLockIcon(bool isVisible);

        void ShowCoin(bool isVisible);

        void ShowProgress(bool isVisible);

        void ShowPrice(bool isVisible);
    }
}