using UnityEngine;

namespace Gameplay.Weapon
{
    [CreateAssetMenu(fileName = "NewBulletStyle", menuName = "Space Invaders/BulletStyle", order = 0)]
    public class BulletTuner : ScriptableObject
    {
        public Sprite sprite;
        public Color color;
        
        public Bullet Tune(Bullet bullet) => 
            bullet.SetSpriteAndColor(sprite, color);
    }
}