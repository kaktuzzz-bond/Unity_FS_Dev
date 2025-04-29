using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Vfx
{
    public class ColorBlinkEffect : IVisualFX, IInitializable
    {
        private readonly Color _blinkColor;
        private readonly SpriteRenderer _targetSprite;
        private readonly float _blinkDuration;
        private readonly int _blinkFrequency;
        private const float RestoreColorDuration = 0.1f;
        private float _calculatedDuration;
        private int _calculatedFrequency;
        private Color _originalColor;
        private Tween _tween;

        public ColorBlinkEffect(Color blinkColor, SpriteRenderer targetSprite, float blinkDuration, int blinkFrequency)
        {
            _blinkColor = blinkColor;
            _targetSprite = targetSprite;
            _blinkDuration = blinkDuration;
            _blinkFrequency = blinkFrequency;
        }

        public void Initialize()
        {
            _originalColor = _targetSprite.color;
            _calculatedFrequency = _blinkFrequency * 2;
            _calculatedDuration = (_blinkDuration - RestoreColorDuration) / _calculatedFrequency;
        }


        [Button, HideInEditorMode]
        public void Play(Action onComplete)
        {
            _tween?.Kill(true);

            _tween = DOTween
                     .Sequence()
                     .Join(_targetSprite.DOColor(_blinkColor, _calculatedDuration)
                                        .SetEase(Ease.InOutSine)
                                        .SetLoops(_calculatedFrequency, LoopType.Yoyo))
                     .Append(_targetSprite.DOColor(_originalColor, RestoreColorDuration))
                     .OnComplete(() => onComplete?.Invoke())
                     ;
        }
    }
}