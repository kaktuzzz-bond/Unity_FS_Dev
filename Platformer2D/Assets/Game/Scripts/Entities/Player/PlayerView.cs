using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private ParticleSystem pushVFX;

        [SerializeField]
        private ParticleSystem tossVFX;

        public void ShowTakenDamage(float healthValue)
        {
            healthBarView.SetValue(healthValue);
        }

        public void PlayPush() => pushVFX.Play();

        public void PlayToss() => tossVFX.Play();
    }
}