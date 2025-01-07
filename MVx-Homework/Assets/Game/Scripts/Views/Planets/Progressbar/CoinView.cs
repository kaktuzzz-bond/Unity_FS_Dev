using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planets.Progressbar
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private Image iconImage;


        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }


        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}