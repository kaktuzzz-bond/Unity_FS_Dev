using Game.Scripts.Components.Vfx;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        public void ShowTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);

            blinkVFX.Play(() =>
            {
                if (healthValue <= 0f) gameObject.SetActive(false);
            });
        }
    }
}