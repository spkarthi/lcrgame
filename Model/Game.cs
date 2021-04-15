using System.Collections.Generic;

namespace LCRGame.Model
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public List<Die> Dice { get; set; }

        public int CurrentPlayer { get; set; }

        public int Turn { get; set; }

        public bool HasWinner { get; set; }

        public Player Winner { get; set; }

        public Game(int totalPlayers)
        {
            Players = new List<Player>();
            for (int i = 0; i < totalPlayers; i++)
            {
                Players.Add(new Player());
            }
            HasWinner = false;
            Turn = 0;
            CurrentPlayer = 0;
        }

        public Player GetCurrentPlayer()
        {
            return Players[CurrentPlayer];
        }

        public Player GetPlayerRight()
        {
            var playerRight = CurrentPlayer + 1;
            if (playerRight == Players.Count)
            {
                return Players[0];
            }
            else
            {
                return Players[playerRight];
            }
        }

        public Player GetPlayerLeft()
        {
            var playerLeft = CurrentPlayer - 1;
            if (playerLeft < 0)
            {
                return Players[Players.Count];
            }
            else
            {
                return Players[playerLeft];
            }
        }

        public void PlayTurn()
        {
            var player = Players[CurrentPlayer];
            var playerRolls = player.GetRolls();

            InitializeDice(playerRolls);

            for (int i = 0; i < playerRolls; i++)
            {
                var result = Dice[i].Roll();
                switch (result)
                {
                    case "L":
                        player.RemoveChips(1);
                        GetPlayerLeft().AddChips(1);
                        break;
                    case "R":
                        player.RemoveChips(1);
                        GetPlayerRight().AddChips(1);
                        break;
                    case "C":
                        player.RemoveChips(1);
                        break;
                }
            }

            if (player.Chips == 0) { CheckWinner(); }

            NextPlayer();

            Turn++;
        }

        private void InitializeDice(int rolls)
        {
            Dice = new List<Die>();
            for (int i = 0; i < rolls; i++)
            {
                Dice.Add(new Die());
            }
        }

        private void CheckWinner()
        {
            var playersWithoutChips = 0;
            var winner = new Player();
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Chips == 0)
                    playersWithoutChips++;
                else
                    winner = Players[i];
            }

            if (Players.Count - playersWithoutChips == 1)
            {
                Winner = winner;
                HasWinner = true;
            }
        }

        private void NextPlayer()
        {
            CurrentPlayer++;
            if (CurrentPlayer == Players.Count)
            {
                CurrentPlayer = 0;
            }
        }
    }
}