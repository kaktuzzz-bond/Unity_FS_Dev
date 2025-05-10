using System;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Vfx;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private HealthBarView healthBarView;

        [SerializeField]
        private ParticleSystem pushVFX;

        [SerializeField]
        private ParticleSystem tossVFX;
        


        public void ShowTakenDamage(float healthValue) => healthBarView.SetValue(healthValue);

        public void PlayPush() => pushVFX.Play();

        public void PlayToss() => tossVFX.Play();
        public void PlayDeath() => gameObject.SetActive(false);
        
    }
}