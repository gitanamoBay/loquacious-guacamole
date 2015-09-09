using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Loquacious.Interfaces;

namespace Loquacious
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window,IGamePlayWindow
    {
        public GameWindow(IGame game)
        {
            InitializeComponent();
            Game = game;
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
            }
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartGameButton.Visibility = Visibility.Hidden;

            var t = new System.Timers.Timer(1000) {AutoReset = false};
            t.Start();
            t.Elapsed += (o, args) =>
            {
                Dispatcher.Invoke(() => StartGameButton.Visibility = Visibility.Visible);
            };
        }


    }
}
