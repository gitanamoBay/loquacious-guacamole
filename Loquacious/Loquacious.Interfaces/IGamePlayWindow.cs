namespace Loquacious.Interfaces
{
    public interface IGamePlayWindow
    {
        IGame Game { get; set; }
        void DisplayGame();
    }
}