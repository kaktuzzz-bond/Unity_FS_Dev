namespace Game.Scripts.Game.Core.Cooldown
{
    public interface ICooldownTimer
    {
        bool IsInProgress { get; }

        void Launch();
    }
}