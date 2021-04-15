using LCRGame.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LCRGame.ViewModel
{
    internal class MainWindowViewModel
    {
        public ICommand PlayCommand { get; set; }

        public int NumberOfPlayers { get; set; }
        public int NumberOfGames { get; set; }

        public IEnumerable<int> Turns { get; set; }

        public Game LCRGame { get; set; }

        public MainWindowViewModel()
        {
            PlayCommand = new RelayCommand(x => Play());
            NumberOfPlayers = 3;
            NumberOfGames = 10;

            LCRGame = new Game(NumberOfPlayers);
        }

        public void Play()
        {
            var turns = new List<int>();
            for (int i = 1; i <= NumberOfGames; i++)
            {
                LCRGame = new Game(NumberOfPlayers);
                while (!LCRGame.HasWinner)
                {
                    LCRGame.PlayTurn();
                }
                turns.Add(LCRGame.Turn);
            }
            Turns = turns;
            var message = $"Longest Turn: {Turns.Max()} , Shortest Turn: {Turns.Min()} , Average Turn: {Turns.Average()}";
            
            MessageBox.Show(message);
        }
    }
}