namespace Modules.UI
{
    public interface IGameUI
    {
        void SetDifficulty(int current, int max);
        void SetScore(string score);
        void GameOver(bool win);
    }
}