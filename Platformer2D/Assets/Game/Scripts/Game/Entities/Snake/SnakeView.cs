using Cysharp.Threading.Tasks;
using Game.Scripts.Game.Core.VFX;
using UnityEngine;

namespace Game.Scripts.Game.Entities.Snake
{
    public class SnakeView : MonoBehaviour
    {
        [SerializeField]
        private BlinkSpriteComponent blinkVFX;

        public UniTask ShowTakenDamage(float healthValue)
        {
            return blinkVFX.Play();
        }
        
        public async UniTaskVoid PlayDeath()
        {
            await ShowTakenDamage(0f);
            gameObject.SetActive(false);
        }
    }
}