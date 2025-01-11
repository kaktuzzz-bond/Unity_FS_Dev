using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Game.Scripts.Views.Common.Utils;

namespace Game.Scripts.Views.HUD
{
    public class MoneyView : MonoBehaviour, IMoneyView
    {
        public Vector3 AttractorPosition => icon.transform.position;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private TMP_Text currencyText;

        [Header("Animation")]
        [SerializeField]
        private float animationDuration = 1.0f;

        [SerializeField]
        private Color spendColor;

        [SerializeField]
        private Color earnColor;


        public void SetIcon(Sprite sprite) =>
            icon.sprite = sprite;


        public void ChangeMoney(string amount)
        {
            currencyText.text = amount;
            BounceAnimation();
        }


        public void SpendMoney(string amount)
        {
            currencyText.text = amount;

            var sequence = DOTween.Sequence();

            sequence
                .Join(BounceAnimation())
                .Join(ColorAnimation(spendColor));
        }


        public void AddMoney(int newValue, int prevValue) =>
            DOTween.Sequence()
                   .Join(AddMoneyAnimation(newValue, prevValue))
                   .Join(BounceAnimation())
                   .Join(ColorAnimation(earnColor));


        private Tween AddMoneyAnimation(int newValue, int prevValue) =>
            DOVirtual.Int(prevValue, newValue, animationDuration,
                          amount => currencyText.text = FormatInt(amount));


        private Tween ColorAnimation(Color color, float interval = 0.5f) =>
            DOTween.Sequence()
                   .Append(currencyText.DOColor(color, 0.1f))
                   .AppendInterval(interval)
                   .Append(currencyText.DOColor(Color.black, 0.3f));


        private Tween BounceAnimation() =>
            DOTween.Sequence()
                   .Append(currencyText.transform.DOScale(new Vector3(1.1f, 1.1f, 1.0f), 0.2f))
                   .Append(currencyText.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.4f));
    }
}