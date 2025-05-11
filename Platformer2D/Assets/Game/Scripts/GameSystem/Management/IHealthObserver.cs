namespace Game.Scripts.GameSystem.Management
{
    public interface IHealthObserver
    {
        void OnDeath();
        void OnHealthChanged(float healthValue);
    }
}