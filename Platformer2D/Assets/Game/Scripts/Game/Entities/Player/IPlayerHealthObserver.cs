namespace Game.Scripts.Game.Entities.Player
{
    public interface IPlayerHealthObserver
    {
        void OnDeath();
        void OnHealthChanged(float healthValue);
    }
}