using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] public Image fillImage;
        [SerializeField] public Gradient gradient;

        public void SetValue(float value)
        {
            fillImage.fillAmount = value;
            gradient.Evaluate(value);
        }
    }
}