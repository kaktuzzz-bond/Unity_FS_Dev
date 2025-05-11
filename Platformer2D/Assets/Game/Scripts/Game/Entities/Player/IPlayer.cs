using UnityEngine;

namespace Game.Scripts.Game.Entities.Player
{
    public interface IPlayer
    {
        void Move(Vector2 direction);

        void Jump();

        void Push();

        void Toss();

        void TakeDamage(int damage);
    }
}