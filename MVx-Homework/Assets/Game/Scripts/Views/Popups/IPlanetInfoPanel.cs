using UnityEngine;

namespace Game.Scripts.Views.Popups
{
    public interface IPlanetInfoPanel
    {
        void SetAvatar(Sprite sprite);

        void SetPopulationText(string text);

        void SetLevelText(string text);

        void SetIncomeText(string text);
    }
}