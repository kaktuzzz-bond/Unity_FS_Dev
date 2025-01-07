using Game.Scripts.Views.Planets.Price;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.Views.Popups
{
    public class PlanetPopupView : MonoBehaviour
    {
        public event UnityAction OnCloseClicked
        {
            add => closeButton.onClick.AddListener(value);
            remove => closeButton.onClick.RemoveListener(value);
        }

        public event UnityAction OnUpgradeClicked
        {
            add => upgradeButton.onClick.AddListener(value);
            remove => upgradeButton.onClick.RemoveListener(value);
        }

        [Header("Header")]
        [SerializeField]
        private TMP_Text headerText;

        [SerializeField]
        private Button closeButton;

        [Header("Body")]
        [SerializeField]
        private Image planetAvatar;

        [SerializeField]
        private TMP_Text populationText;

        [SerializeField]
        private TMP_Text levelText;

        [SerializeField]
        private TMP_Text incomeText;

        [Header("Button")]
        [SerializeField]
        private TMP_Text buttonText;

        [SerializeField]
        private PriceView price;

        [SerializeField]
        private Button upgradeButton;


        private void Awake()
        {
            Hide();
        }


        public void Show() =>
            gameObject.SetActive(true);


        public void Hide() =>
            gameObject.SetActive(false);


        public void SetHeaderText(string text) =>
            headerText.text = text;


        public void SetAvatar(Sprite img) =>
            planetAvatar.sprite = img;


        public void SetPopulationText(string text) =>
            populationText.text = text;


        public void SetLevelText(string text) =>
            levelText.text = text;


        public void SetIncomeText(string text) =>
            incomeText.text = text;


        public void SetPriceText(string text) =>
            price.SetText(text);

        public void SetButtonText(string text) =>
            buttonText.SetText(text);
        
        public void SetButtonInteractable(bool interactable)
        {
            price.SetActive(interactable);
            upgradeButton.interactable = interactable;
        }
    }
}