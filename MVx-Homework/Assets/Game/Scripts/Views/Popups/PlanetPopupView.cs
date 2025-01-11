using Game.Scripts.Views.Buttons;
using Sirenix.OdinInspector;
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

        public IPlanetInfoPanel PlanetInfoPanel => planetInfoPanel;
        public IUpgradeButtonView UpgradeButton => upgradeButton;

        [Header("Header")]
        [SerializeField]
        private TMP_Text headerText;

        [SerializeField]
        private Button closeButton;

        [Header("Body")]
        [SerializeField]
        private PlanetInfoPanel planetInfoPanel;

        [SerializeField]
        private UpgradeButtonView upgradeButton;


        private void Awake() => 
            Hide();


        public void Show() =>
            gameObject.SetActive(true);


        public void Hide() =>
            gameObject.SetActive(false);


        public void SetHeaderText(string text) =>
            headerText.text = text;
    }
}