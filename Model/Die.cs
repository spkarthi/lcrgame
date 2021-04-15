using System;

namespace LCRGame.Model
{
    public class Die
    {
        private static string[] sides = new string[] { "L", "C", "R", ".", ".", "." };
        public string LastRoll { get; set; }

        public string Roll()
        {
            Random DiceRandom = new Random();
            int randomNumber = DiceRandom.Next(1, 6);
            LastRoll = sides[randomNumber];
            return sides[randomNumber];
        }
    }
}