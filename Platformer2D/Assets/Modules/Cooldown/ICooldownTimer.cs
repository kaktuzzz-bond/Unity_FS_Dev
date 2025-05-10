namespace Modules.Cooldown
{
    public interface ICooldownTimer
    {
        bool IsInProgress { get; }

        void Launch();
    }
}