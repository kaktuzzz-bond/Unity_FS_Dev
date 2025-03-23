namespace Game.Scripts.Components.Health
{
    public interface IHealthComponent : IDamagable
    {
        public float Health { get; }
        bool IsDead { get; }

        void Restore();
    }
}