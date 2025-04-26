using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public class PlayerProxy : MonoBehaviour, IPlayerProxy
    {
        [SerializeField]
        public Entity entity;

        public IEntity GetEntity => entity;
    }
}