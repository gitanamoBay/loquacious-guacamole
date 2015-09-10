using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : IGamePlayWindow
    {
        public GameWindow(IGame game)
        {
            InitializeComponent();
            Game = game;
            Game.GameEnds = OnGameCompleted;
            Game.CountDownTickOne = () => {
                Dispatcher.Invoke(() =>
                {
                    CountDownLabel.Content = "Rock";
                });
            };
            Game.CountDownTickTwo = () => {
                Dispatcher.Invoke(() =>
                {
                    CountDownLabel.Content = "Paper";

                });
            };
            Game.CountDownTickGo = () => {
                Dispatcher.Invoke(() =>
                {
                    CountDownLabel.Content = "Scissors";
                });
            };
        }

        public IGame Game { get; set; }

        public void DisplayGame()
        {
            this.Show();
        }

        private void KeyWasPressed(object sender, KeyEventArgs e)
        {
            if (e.IsUp)
            {
                var players = Game.Players.Where(x => x is INonNpc).ToList();
                foreach (INonNpc player in players)
                {
                    if (player.KeysAccepted.Contains(e.Key))
                    {
                        player.KeyStroke(e.Key);
                    }
                }
            }
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartGameButton.Visibility = Visibility.Hidden;
            Game.StartGame();
        }

        private void OnGameCompleted(Result result, int winner)
        {
            Dispatcher.Invoke(() =>
            {

                StartGameButton.Visibility = Visibility.Visible;
                DisplayPicks();

                UpdateScores(result, winner);
            });
        }

        private void DisplayPicks()
        {
            setImageForPick(Game.Players.ElementAt(0).Pick,PlayerOneImage);
            setImageForPick(Game.Players.ElementAt(1).Pick,PlayerTwoImage);
        }

        private void setImageForPick(Pick pick, Image image)
        {
            switch (pick)
            {
                case Pick.None:
                    image.Source = new BitmapImage();
                    break;
                case Pick.Paper:
                    image.Source = new BitmapImage(new Uri(@"/paper.png", UriKind.Relative));
                    break;
                case Pick.Rock:
                    image.Source = new BitmapImage(new Uri(@"/rock.png", UriKind.Relative));
                    break;
                case Pick.Scissors:
                    image.Source = new BitmapImage(new Uri(@"/scissors.png", UriKind.Relative));
                    break;
            }
        }

        private int leftScore;
        private int rightScore;

        private void UpdateScores(Result result, int winner)
        {
            if (result == Result.Victory)
            {
                if (winner == 0)
                    leftScore++;
                else
                    rightScore++;

                PlayerOneScore.Content = leftScore;
                PlayerTwoScore.Content = rightScore;

                CountDownLabel.Content = "Player " + (winner+1) + " wins.";
            }
            else
            {
                if (result == Result.NoPicks)
                {
                    CountDownLabel.Content = "no picks.";

                }
                else
                    CountDownLabel.Content = "tie.";
            }
        }
    }
}
