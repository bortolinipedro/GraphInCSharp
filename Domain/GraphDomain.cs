using System;
using System.Linq;
using System.Collections.Generic;
using GraphInCSharp.Domain.Models;
using GraphInCSharp.Domain.Representations;

namespace GraphInCSharp.Domain
{
    public class GraphDomain
    {
        public Graph Graph { get; set; }
        
        public GraphDomain() {}

        public Graph CreateGraph(int numVertices)
        {
            this.Graph = new Graph(numVertices);
            this.Graph.EdgeList = new Dictionary<string, Edge>();
            this.Graph.VertexList = new Dictionary<int, Vertex>();
            this.Graph.AdjacencyMatrix = new AdjacencyMatrix(numVertices);
            this.Graph.AdjacencyList = new AdjacencyList();

            return this.Graph;
        }

        public void AddVertex(Vertex vertex)
        {
            this.Graph.VertexList[vertex.Id] = vertex;
            this.Graph.AdjacencyList.AddVertex(vertex);
        }

        public void Connect(int sourceVertexId, int targetVertexId, int weight)
        {
            if (weight == 0) {
                Console.WriteLine("Peso 0 não permitido");
                return;
            }

            Edge edge = new Edge(sourceVertexId, targetVertexId, weight);

            if (this.IsConnected(sourceVertexId, targetVertexId)) {
                Console.WriteLine("Erro. Aresta existente");
                return;
            }

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            this.Graph.EdgeList.Add(edgeIdentifier, edge);

            this.Graph.AdjacencyMatrix.Connect(sourceVertexId, targetVertexId, weight);
            this.Graph.AdjacencyList.Connect(sourceVertexId, targetVertexId);
        }

        public void AddEdgeWeight(int sourceVertexId, int targetVertexId, int weight)
        {
            if (weight == 0) {
                Console.WriteLine("Peso 0 não permitido");
                return;
            }

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var edge = this.GetEdgeByIdentifier(edgeIdentifier);

            if (edge == null)
            {
                Console.WriteLine("Aresta não encontrada.");
                return;
            }

            edge.Weight = weight;
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            this.Graph.EdgeList.Remove(edgeIdentifier);

            this.Graph.AdjacencyMatrix.Disconnect(sourceVertexId, targetVertexId);
            this.Graph.AdjacencyList.Disconnect(sourceVertexId, targetVertexId);
        }

        public Vertex GetVertexById(int id)
        {
            if (!this.Graph.VertexList.ContainsKey(id)) {
                return null;
            }

            return this.Graph.VertexList[id];
        }

        public Edge GetEdgeByIdentifier(string identifier)
        {
            if (!this.Graph.EdgeList.ContainsKey(identifier)) {
                return null;
            }

            return this.Graph.EdgeList[identifier];
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int sourcePosition = 0; sourcePosition < this.Graph.AdjacencyMatrix.GetLength(0); sourcePosition++)
            {
                for (int targetPosition = 0; targetPosition < this.Graph.AdjacencyMatrix.GetLength(1); targetPosition++)
                {
                    var edgeIdentifier = (sourcePosition + 1) + "_" + (targetPosition + 1);
                    var edge = this.GetEdgeByIdentifier(edgeIdentifier);
                    
                    if (edge != null) {
                        Console.Write("{EdgeLabel: " + edge.Label + " - EdgeWeight: " + edge.Weight + "}" + " ");
                    } else {
                        Console.Write(this.Graph.AdjacencyMatrix.GetValue(sourcePosition, targetPosition) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Lista de Adjacência:");
            foreach (var vertexAdjacency in this.Graph.AdjacencyList.GetList())
            {
                var vertex = this.GetVertexById(vertexAdjacency.Key);
                if (vertex != null) {
                    Console.Write("{VertexId: " + vertex.Id + " - VertexLabel: " + vertex.Label + " - VertexWeight: " + vertex.Weight + "}" + ": ");
                } else {
                    Console.Write("?" + " ");
                }

                foreach (var adjacentVertex in vertexAdjacency.Value)
                {
                    Console.Write(adjacentVertex + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsConnected(int sourceVertexId, int targetVertexId)
        {
            return this.Graph.AdjacencyMatrix.IsConnected(sourceVertexId, targetVertexId);
        }

        public List<int> GetOutNeighbors(int vertexId)
        {
            return this.Graph.AdjacencyList.GetOutNeighbors(vertexId);
        }

        public List<int> GetInNeighbors(int vertexId)
        {
            return this.Graph.AdjacencyList.GetInNeighbors(vertexId);
        }

        public int GetOutVertexDegree(int vertexId)
        {
            return GetOutNeighbors(vertexId).Count;
        }

        public int GetInVertexDegree(int vertexId)
        {
            return GetInNeighbors(vertexId).Count;
        }

        public bool IsComplete()
        {
            int n = this.Graph.VertexList.Count;
            int expectedEdges = n * (n - 1);

            return this.Graph.EdgeList.Count == expectedEdges;
        }

        public bool IsRegular()
        {
            int firstKey = this.Graph.VertexList.Keys.FirstOrDefault();
            int firstInDegree = this.GetInVertexDegree(firstKey);
            int firstOutDegree = this.GetOutVertexDegree(firstKey);
            if (firstInDegree != firstOutDegree) {
                return false;
            }
            
            foreach (int key in this.Graph.VertexList.Keys)
            {
                if (
                    this.GetInVertexDegree(key) != firstInDegree || 
                    this.GetOutVertexDegree(key) != firstOutDegree
                    )
                {
                    return false;
                }
            }

            return true;
        }

        public void DepthFirstSearch(int sourceVertex, HashSet<int> visited)
        {
            if (!visited.Contains(sourceVertex))
            {
                visited.Add(sourceVertex);
                foreach (var neighbor in this.GetOutNeighbors(sourceVertex))
                {
                    this.DepthFirstSearch(neighbor, visited);
                }
            }
        }

        private void ReverseDepthFirstSearch(int sourceVertex, HashSet<int> visited)
        {
            if (!visited.Contains(sourceVertex))
            {
                visited.Add(sourceVertex);
                foreach (var neighbor in this.GetInNeighbors(sourceVertex))
                {
                    this.ReverseDepthFirstSearch(neighbor, visited);
                }
            }
        }

        private void WeakDepthFirstSearch(int vertex, HashSet<int> visited)
        {
            if (!visited.Contains(vertex))
            {
                visited.Add(vertex);
                
                var neighbors = this.GetOutNeighbors(vertex).Concat(this.GetInNeighbors(vertex));
                foreach (var neighbor in neighbors)
                {
                    this.WeakDepthFirstSearch(neighbor, visited);
                }
            }
        }

        public List<int> BreadthFirstSearch(int sourceVertex)
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            List<int> result = new List<int>();

            queue.Enqueue(sourceVertex);
            visited.Add(sourceVertex);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                result.Add(vertex);

                foreach (var neighbor in this.GetOutNeighbors(vertex))
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        public Dictionary<int, int> Dijkstra(int sourceVertex)
        {
            Dictionary<int, int> distances = this.Graph.VertexList.Keys.ToDictionary(v => v, v => int.MaxValue);
            distances[sourceVertex] = 0;

            List<int> unvisitedVertices = this.Graph.VertexList.Keys.ToList();

            while (unvisitedVertices.Count > 0)
            {
                int currentVertex = unvisitedVertices
                    .OrderBy(v => distances.ContainsKey(v) ? distances[v] : int.MaxValue)
                    .FirstOrDefault();
                
                unvisitedVertices.Remove(currentVertex);

                foreach (var neighbor in this.GetOutNeighbors(currentVertex))
                {
                    if (!unvisitedVertices.Contains(neighbor)) continue;

                    var edgeIdentifier = currentVertex + "_" + neighbor;
                    var edge = this.GetEdgeByIdentifier(edgeIdentifier);
                    int newDistance = distances[currentVertex] + edge.Weight;

                    if (newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                    }
                }
            }

            return distances;
        }

        public int[,] FloydWarshall()
        {
            int numVertices = this.Graph.VertexList.Count;
            int[,] distances = new int[numVertices, numVertices];

            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    int iVertex = i + 1;
                    int jVertex = j + 1;

                    if (i == j)
                        distances[i, j] = 0;
                    else if (this.Graph.AdjacencyMatrix.IsConnected(iVertex, jVertex)) {
                        var edgeIdentifier = (iVertex) + "_" + (jVertex);
                        var edge = this.GetEdgeByIdentifier(edgeIdentifier);
                        distances[i, j] = edge.Weight;
                    }
                    else
                        distances[i, j] = int.MaxValue;
                }
            }

            for (int k = 0; k < numVertices; k++)
            {
                for (int i = 0; i < numVertices; i++)
                {
                    for (int j = 0; j < numVertices; j++)
                    {
                        if (distances[i, k] != int.MaxValue && distances[k, j] != int.MaxValue)
                        {
                            distances[i, j] = Math.Min(distances[i, j], distances[i, k] + distances[k, j]);
                        }
                    }
                }
            }

            return distances;
        }

        public bool IsConnectedGraph()
        {
            if (this.Graph.VertexList.Count == 0)
                return true;

            var visited = new HashSet<int>();
            DepthFirstSearch(this.Graph.VertexList.Keys.First(), visited);

            return visited.Count == this.Graph.VertexList.Count;
        }

        public bool IsStronglyConnected()
        {
            foreach (var vertex in this.Graph.VertexList.Keys)
            {
                if (!this.CanReachAllVertices(vertex) || !this.CanReachAllVerticesInReverse(vertex))
                    return false;
            }
            return true;
        }

        public bool IsWeaklyConnected()
        {
            var visited = new HashSet<int>();
            int sourceVertex = this.Graph.VertexList.Keys.FirstOrDefault();
            
            this.WeakDepthFirstSearch(sourceVertex, visited);
            
            return visited.Count == this.Graph.VertexList.Count;
        }

        private bool CanReachAllVertices(int sourceVertex)
        {
            var visited = new HashSet<int>();
            this.DepthFirstSearch(sourceVertex, visited);
            return visited.Count == this.Graph.VertexList.Count;
        }

        private bool CanReachAllVerticesInReverse(int sourceVertex)
        {
            var visited = new HashSet<int>();
            this.ReverseDepthFirstSearch(sourceVertex, visited);
            return visited.Count == this.Graph.VertexList.Count;
        }

        public bool IsEulerian()
        {
            if (!this.IsConnectedGraph())
                return false;

            foreach (var vertexId in this.Graph.VertexList.Keys)
            {
                if (this.GetInVertexDegree(vertexId) != this.GetOutVertexDegree(vertexId))
                    return false;
            }

            return true;
        }

        public bool IsAcyclic()
        {
            var visited = new HashSet<int>();
            var inStack = new HashSet<int>();

            foreach (var vertex in this.Graph.VertexList.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    if (HasCycle(vertex, visited, inStack))
                        return false;
                }
            }

            return true;
        }

        private bool HasCycle(int vertex, HashSet<int> visited, HashSet<int> inStack)
        {
            visited.Add(vertex);
            inStack.Add(vertex);

            foreach (var neighbor in this.GetOutNeighbors(vertex))
            {
                if (!visited.Contains(neighbor))
                {
                    if (HasCycle(neighbor, visited, inStack))
                        return true;
                }
                else if (inStack.Contains(neighbor)) // Encontrou um ciclo
                {
                    return true;
                }
            }

            inStack.Remove(vertex);
            return false;
        }
    }
}
