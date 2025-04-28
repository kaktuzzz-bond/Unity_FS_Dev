namespace Game.Scripts.Components.Jump
{
    public interface ICooldownTimer
    {
        bool IsInProgress { get; }

        void Launch();
    }
}