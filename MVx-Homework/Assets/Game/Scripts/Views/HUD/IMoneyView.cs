using UnityEngine;

namespace Game.Scripts.Views.HUD
{
    public interface IMoneyView
    {
        public Vector3 AttractorPosition { get; }
        void SetIcon(Sprite sprite);

        void SetText(string text);
    }
}