using System;
using Game.Scripts.Views.Planets.Price;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.Views.Buttons
{
    public class UpgradeButtonView : MonoBehaviour, IUpgradeButtonView
    {
        public event UnityAction OnClicked
        {
            add => button.onClick.AddListener(value);
            remove => button.onClick.RemoveListener(value);
        }

        public IIconTextView Price => price;

        [SerializeField]
        private Button button;

        [SerializeField]
        private TMP_Text buttonText;

        [SerializeField]
        private IconTextView price;


        public void SetText(string text) =>
            buttonText.text = text;


        public void SetButtonInteractable(bool interactable) =>
            button.interactable = interactable;
    }
}