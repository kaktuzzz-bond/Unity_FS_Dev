namespace Game.Scripts.Views.Planets.Progressbar
{
    public interface IProgressbarView
    {
        void SetProgress(float progress);

        void SetTimerText(string text);

        void Show();

        void Hide();
    }
}