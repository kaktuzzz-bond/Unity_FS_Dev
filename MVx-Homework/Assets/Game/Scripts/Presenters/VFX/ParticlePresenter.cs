using System;
using Game.Scripts.Presenters.HUD;
using Game.Scripts.Presenters.Planets;
using Modules.Planets;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters.VFX
{
    public class ParticlePresenter : IInitializable, IDisposable
    {
        private readonly PlanetClickListener _planetClickListener;
        private readonly ParticleAnimator _particleAnimator;
        private readonly MoneyViewPresenter _moneyViewPresenter;

        private const float ParticleDuration = 1f;


        public ParticlePresenter(PlanetClickListener planetClickListener,
                                 ParticleAnimator particleAnimator,
                                 MoneyViewPresenter moneyViewPresenter)
        {
            _planetClickListener = planetClickListener;
            _particleAnimator = particleAnimator;
            _moneyViewPresenter = moneyViewPresenter;
        }


        public void Initialize()
        {
            _planetClickListener.OnPlanetIncomeGathered += EmitParticles;
        }


        private void EmitParticles(PlanetPresenter planetPresenter)
        {
            var from = planetPresenter.CoinPosition;
            var to = _moneyViewPresenter.AttractorPosition;

            _particleAnimator.Emit(from, to, ParticleDuration);
        }


        public void Dispose()
        {
            _planetClickListener.OnPlanetIncomeGathered -= EmitParticles;
        }
    }
}