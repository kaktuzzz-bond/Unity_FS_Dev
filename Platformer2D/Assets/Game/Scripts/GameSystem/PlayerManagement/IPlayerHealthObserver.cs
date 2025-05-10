using Unity.VisualScripting;

namespace Game.Scripts.GameSystem.PlayerManagement
{
    public interface IPlayerHealthObserver
    {
        void OnDeath();
        void OnHealthChanged(float healthValue);
    }
}