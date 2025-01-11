using Game.Scripts.Views.Planets.Price;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Popups
{
    public class PlanetInfoPanel : MonoBehaviour, IPlanetInfoPanel
    {
        [SerializeField]
        private Image planetAvatar;

        [SerializeField]
        private IconTextView population;

        [SerializeField]
        private IconTextView level;

        [SerializeField]
        private IconTextView income;


        public void SetAvatar(Sprite sprite) =>
            planetAvatar.sprite = sprite;


        public void SetPopulationText(string text) =>
            population.SetText(text);


        public void SetLevelText(string text) =>
            level.SetText(text);


        public void SetIncomeText(string text) =>
            income.SetText(text);
    }
}