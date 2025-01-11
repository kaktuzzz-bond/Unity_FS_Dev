using UnityEngine;

namespace Game.Scripts.Views.HUD
{
    public interface IMoneyView
    {
        public Vector3 AttractorPosition { get; }

        void SetIcon(Sprite sprite);

        void ChangeMoney(string amount);


        void SpendMoney(string amount);


        void AddMoney(int newValue, int prevValue);
    }
}