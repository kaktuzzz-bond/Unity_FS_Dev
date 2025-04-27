using UnityEngine;

namespace Game.Scripts.Enemies.Trap
{
    public class TrapView : MonoBehaviour
    {
        public void ShowTakenDamage(float healthValue)
        {
            if (healthValue <= 0f) 
                gameObject.SetActive(false);
        }
    }
}