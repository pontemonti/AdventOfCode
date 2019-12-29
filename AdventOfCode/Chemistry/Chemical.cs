namespace Pontemonti.AdventOfCode.Chemistry
{
    public class Chemical
    {
        public Chemical(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; }
        public long Quantity { get; }
    }
}