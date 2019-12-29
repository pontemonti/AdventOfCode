namespace Pontemonti.AdventOfCode.Chemistry
{
    public class Chemical
    {
        public Chemical(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; }
        public int Quantity { get; }
    }
}