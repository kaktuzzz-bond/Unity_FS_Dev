using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Game.Core.MonoComponents
{
   
    public class BlinkSpriteComponent : MonoBehaviour
    {
        [SerializeField]
        private Color blinkColor;

        [SerializeField]
        private SpriteRenderer targetSprite;

        [SerializeField, Min(0)]
        private float blinkDuration = 2;

        [SerializeField, Min(0)]
        private int blinkFrequency = 10;

        private const float RestoreColorDuration = 0.1f;
        private float _calculatedDuration;
        private int _calculatedFrequency;
        private Color _originalColor;
        private Tween _tween;

        private void Awake()
        {
            _originalColor = targetSprite.color;
            _calculatedFrequency = blinkFrequency * 2;
            _calculatedDuration = (blinkDuration - RestoreColorDuration) / _calculatedFrequency;
        }

        [Button, HideInEditorMode]
        public UniTask Play()
        {
            _tween?.Kill(true);

            _tween = DOTween
                     .Sequence()
                     .Join(targetSprite.DOColor(blinkColor, _calculatedDuration)
                                       .SetEase(Ease.InOutSine)
                                       .SetLoops(_calculatedFrequency, LoopType.Yoyo))
                     .Append(targetSprite.DOColor(_originalColor, RestoreColorDuration));

            return _tween.ToUniTask(cancellationToken: destroyCancellationToken);
        }
    }
}