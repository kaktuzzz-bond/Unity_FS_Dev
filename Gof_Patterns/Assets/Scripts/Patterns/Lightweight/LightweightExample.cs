using UnityEngine;

namespace Patterns.Lightweight
{
    [CreateAssetMenu(fileName = "NewLightweight", menuName = "Gof/Lightweight/LightweightExample", order = 0)]
    public class LightweightExample : ScriptableObject
    {
        public string title;
        public Sprite icon;
        public float speed;
        public int attackDamage;
        
        //...etc

    }
}