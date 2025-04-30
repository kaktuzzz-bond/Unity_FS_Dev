using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Vfx
{
    public class ColorBlinkEffectInstaller : Installer<Color, SpriteRenderer, float, int, ColorBlinkEffectInstaller>
    {
        private readonly Color _blinkColor;
        private readonly SpriteRenderer _targetSprite;
        private readonly float _blinkDuration;
        private readonly int _blinkFrequency;

        public ColorBlinkEffectInstaller(
            Color blinkColor, SpriteRenderer targetSprite, float blinkDuration, int blinkFrequency)
        {
            _blinkColor = blinkColor;
            _targetSprite = targetSprite;
            _blinkDuration = blinkDuration;
            _blinkFrequency = blinkFrequency;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ColorBlinkEffect>()
                     .AsSingle()
                     .WithArguments(_blinkColor, _targetSprite, _blinkDuration, _blinkFrequency);
        }
    }
}