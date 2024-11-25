using Modules.Inventories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class ItemPopup : MonoBehaviour
    {
        private IItemPresenter _presenter;
        
        [SerializeField]
        private Button _consumeButton;

        [SerializeField]
        private TMP_Text _title;

        [SerializeField]
        private TMP_Text _description;

        [SerializeField]
        private TMP_Text _count;
        
        [SerializeField]
        private Image _icon;

        [Inject]
        public void Construct(IItemPresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _consumeButton.interactable = _presenter.IsConsumable;
            _consumeButton.onClick.AddListener(OnConsumeButtonClicked);
            UpdateView();
        }

        private void OnDisable()
        {            
            _consumeButton.onClick.RemoveListener(OnConsumeButtonClicked);
        }

        private void OnConsumeButtonClicked()
        {
            _presenter.Consume();
        }

        private void UpdateView()
        {
            _title.text = _presenter.Title;
            _description.text = _presenter.Description;
            _count.text = _presenter.Count;
            _icon.sprite = _presenter.Icon;
        }
    }
}