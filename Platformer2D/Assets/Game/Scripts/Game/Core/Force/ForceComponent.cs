using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    public class ForceComponent : IForceComponent
    {
        public void AddForce(Rigidbody2D rigidbody, Vector2 force)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}