namespace Game.Scripts.Components.Health
{
    public class HealthComponent
    {
        private readonly int _maxHealth;
        private int _currentHealth;

        public HealthComponent(int maxHealth)
        {
            _maxHealth = maxHealth;
        }

        public void TakeDamage(int damage) =>
            _currentHealth -= damage;

        public bool IsDead() =>
            _currentHealth <= 0;
    }
}