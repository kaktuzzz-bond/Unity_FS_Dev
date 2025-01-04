using System;
using UnityEngine;

namespace Game.Scripts.Views.Modifiers
{
    public class PlanetViewModifier : MonoBehaviour
    {
        [SerializeField]
        private PlanetRectTransformModifier[] modifiers;

        private int _currentIndex;


        public void ModifyView(RectTransform rectTransform)
        {
            if (_currentIndex >= modifiers.Length) return;

            var modifier = modifiers[_currentIndex];

            rectTransform.anchoredPosition = modifier.RectPosition;
            rectTransform.sizeDelta = modifier.RectSize;

            _currentIndex++;
        }


        [Serializable]
        private class PlanetRectTransformModifier
        {
            internal Vector2 RectPosition => position;
            internal Vector2 RectSize => size;

            [SerializeField]
            private Vector2 position;

            [SerializeField]
            private Vector2 size = new(350, 350);
        }
    }
}