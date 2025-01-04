using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planets.Progressbar
{
    public class ProgressbarView : MonoBehaviour, IProgressbarView
    {
        [SerializeField]
        private Image progressbar;
        
        [SerializeField]
        private TMP_Text timerText;


        public void SetProgress(float progress)
        {
            progressbar.fillAmount = progress;
        }


        public void SetTimerText(string text)
        {
            timerText.text = text;
        }


        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}