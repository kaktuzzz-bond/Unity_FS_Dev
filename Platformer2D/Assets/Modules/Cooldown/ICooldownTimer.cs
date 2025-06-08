namespace Modules
{
    public interface ICooldownTimer
    {
        bool IsInProgress { get; }

        void Launch();
    }
}