using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Popups
{
    public class PlanetStatInfo : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TMP_Text statText;


        public void SetIcon(Sprite sprite) =>
            icon.sprite = sprite;


        public void SetText(string text) =>
            statText.text = text;
    }
}