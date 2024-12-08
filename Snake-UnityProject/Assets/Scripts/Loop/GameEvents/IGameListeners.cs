namespace Loop.GameEvents
{
    public interface IGameListener
    {
    }


    public interface IGameStartedListener : IGameListener
    {
        void OnGameStarted();
    }


    public interface IGameFinishedListener : IGameListener
    {
        void OnGameFinished();
    }


    public interface IGameWonListener : IGameListener
    {
        void OnGameWon();
    }


    public interface IGameFailedListener : IGameListener
    {
        void OnGameFailed();
    }
}