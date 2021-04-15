namespace LCRGame.Model
{
    public class Player
    {
        private const int maxChips = 3;
        public System.Guid Id { get; set; }
        public int Chips { get; set; }
        //public int Left { get; set; }
        //public int Right { get; set; }
        //public int Position { get; set; }

        public void AddChips(int value)
        {
            Chips += value;
        }

        public void RemoveChips(int value)
        {
            Chips -= value;
        }

        public Player()
        {
            Id = System.Guid.NewGuid();
            Chips = maxChips;
        }

        public int GetRolls()
        {
            if (Chips >= maxChips)
            {
                return maxChips;
            }
            else
            {
                return Chips;
            }
        }
    }
}