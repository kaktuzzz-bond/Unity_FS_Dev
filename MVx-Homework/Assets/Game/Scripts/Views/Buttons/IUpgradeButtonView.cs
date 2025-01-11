using Game.Scripts.Views.Planets.Price;
using UnityEngine.Events;

namespace Game.Scripts.Views.Buttons
{
    public interface IUpgradeButtonView
    {
        event UnityAction OnClicked;
        IIconTextView Price { get; }

        void SetText(string text);

        void SetButtonInteractable(bool interactable);
    }
}