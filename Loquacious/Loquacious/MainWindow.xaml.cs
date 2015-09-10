using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Autofac;
using Loquacious.Interfaces;
using Loquacious.Values;

namespace Loquacious
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnePlayer_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(false);
        }

        private void TwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow(true);
        }

        public void OpenWindow(bool playertwo)
        {
            var game =
                App.Container.Resolve<IEnumerable<IGame>>()
                    .Single(x => x.GameMode == (playertwo ? GameMode.PvsP : GameMode.PvsAi));

            var gamePlaywindow = App.Container.Resolve<IGamePlayWindow>(new NamedParameter("game", game));
            gamePlaywindow.DisplayGame();
        }
    }
}