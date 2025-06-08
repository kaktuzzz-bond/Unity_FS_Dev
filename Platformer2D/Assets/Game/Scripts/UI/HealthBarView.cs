using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        [SerializeField] private Gradient gradient;

        public void SetValue(float value)
        {
            fillImage.fillAmount = value;
            gradient.Evaluate(value);
        }
    }
}