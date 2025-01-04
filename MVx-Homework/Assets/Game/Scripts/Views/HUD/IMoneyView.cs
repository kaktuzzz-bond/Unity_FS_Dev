using UnityEngine;

namespace Game.Scripts.Views.HUD
{
    public interface IMoneyView
    {
        void SetIcon(Sprite sprite);

        void SetText(string text);
    }
}