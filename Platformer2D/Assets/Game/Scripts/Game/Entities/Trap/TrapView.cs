using UnityEngine;

namespace Game.Scripts.Game.Entities.Trap
{
    public class TrapView : MonoBehaviour
    {
        public void PlayDeath()
        {
            gameObject.SetActive(false);
        }
    }
}