namespace Game.Scripts.Components.Cooldown
{
    public interface ICooldownTimer
    {
        bool IsInProgress { get; }

        void Launch();
    }
}