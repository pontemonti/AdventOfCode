namespace Pontemonti.AdventOfCode.Graph
{
    public class Vertex<T>
    {
        public Vertex(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Vertex<T> otherVertex)
            {
                return this.Value.Equals(otherVertex.Value);
            }

            return false;
        }
    }
}