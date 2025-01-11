using UnityEngine;

namespace Game.Scripts.Views.Planets.Price
{
    public interface IIconTextView
    {
        void SetIcon(Sprite sprite);

        void SetText(string text);

        void SetActive(bool isActive);
    }
}