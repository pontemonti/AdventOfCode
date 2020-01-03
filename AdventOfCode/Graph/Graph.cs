using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Graph
{
    public class Graph<T>
    {
        private List<Vertex<T>> vertices;
        private List<Edge<T>> edges;

        public Graph(IEnumerable<Vertex<T>> vertices, IEnumerable<Edge<T>> edges)
        {
            this.vertices = vertices.ToList();
            this.edges = edges.ToList();
        }

        public IEnumerable<Edge<T>> FindPathToFarthestVertex(Vertex<T> sourceVertex)
        {
            Dictionary<Vertex<T>, List<Edge<T>>> visitedVertices = new Dictionary<Vertex<T>, List<Edge<T>>>();
            visitedVertices.Add(sourceVertex, new List<Edge<T>>());

            Queue<Vertex<T>> verticesToVisit = new Queue<Vertex<T>>();
            verticesToVisit.Enqueue(sourceVertex);
            while (verticesToVisit.Any())
            {
                Vertex<T> vertexToVisit = verticesToVisit.Dequeue();
                List<Edge<T>> edgesToVertex = visitedVertices[vertexToVisit];

                List<Edge<T>> adjacentEdges = this.GetAdjacentEdges(vertexToVisit).ToList();
                foreach (Edge<T> adjacentEdge in adjacentEdges)
                {
                    Vertex<T> adjacentVertex = this.GetAdjacentVertex(vertexToVisit, adjacentEdge);
                    if (!visitedVertices.ContainsKey(adjacentVertex))
                    {
                        List<Edge<T>> edgesToAdjacentVertex = new List<Edge<T>>(edgesToVertex.ToArray());
                        edgesToAdjacentVertex.Add(adjacentEdge);
                        visitedVertices.Add(adjacentVertex, edgesToAdjacentVertex);
                        verticesToVisit.Enqueue(adjacentVertex);
                    }
                }
            }

            int maxDistance = 0;
            List<Edge<T>> maxEdges = null;
            foreach (List<Edge<T>> edgePath in visitedVertices.Values)
            {
                if (edgePath.Count > maxDistance)
                {
                    maxDistance = edgePath.Count;
                    maxEdges = edgePath;
                }
            }

            return maxEdges;
        }

        private IEnumerable<Edge<T>> GetAdjacentEdges(Vertex<T> vertex)
            => this.edges.Where(edge => edge.Vertex1.Equals(vertex) || edge.Vertex2.Equals(vertex));

        private Vertex<T> GetAdjacentVertex(Vertex<T> otherVertex, Edge<T> edge)
        {
            if (edge.Vertex1.Equals(otherVertex))
            {
                return edge.Vertex2;
            }
            else
            {
                return edge.Vertex1;
            }
        }
    }
}
