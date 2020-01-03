namespace Pontemonti.AdventOfCode.Graph
{
    public class Edge<T>
    {
        public Edge(Vertex<T> vertex1, Vertex<T> vertex2)
        {
            this.Vertex1 = vertex1;
            this.Vertex2 = vertex2;
        }

        public Vertex<T> Vertex1 { get; }
        public Vertex<T> Vertex2 { get; }
    }
}