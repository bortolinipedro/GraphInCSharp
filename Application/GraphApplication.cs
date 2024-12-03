using System;
using System.Collections.Generic;
using GraphInCSharp.Domain;
using GraphInCSharp.Domain.Models;

namespace GraphInCSharp.Application
{
    public class GraphApplication
    {
        private GraphDomain GraphDomain;

        public GraphApplication()
        {
            this.GraphDomain = new GraphDomain();
        }

        public Graph CreateGraph(int numVertices)
        {
            return this.GraphDomain.CreateGraph(numVertices);
        }

        public void AddVertex(Vertex vertex)
        {
            this.GraphDomain.AddVertex(vertex);
        }

        public void Connect(int sourceVertexId, int targetVertexId, int weight)
        {
            this.GraphDomain.Connect(sourceVertexId, targetVertexId, weight);
        }

        public void AddEdgeWeight(int sourceVertexId, int targetVertexId, int weight)
        {
            this.GraphDomain.AddEdgeWeight(sourceVertexId, targetVertexId, weight);
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            this.GraphDomain.Disconnect(sourceVertexId, targetVertexId);
        }

        public Vertex GetVertexById(int id)
        {
            return this.GraphDomain.GetVertexById(id);
        }

        public Edge GetEdgeByIdentifier(string identifier)
        {
            return this.GraphDomain.GetEdgeByIdentifier(identifier);
        }

        public void PrintAdjacencyMatrix()
        {
            this.GraphDomain.PrintAdjacencyMatrix();
        }

        public void PrintAdjacencyList()
        {
            this.GraphDomain.PrintAdjacencyList();
        }

        public bool IsConnected(int sourceVertexId, int targetVertexId)
        {
            return this.GraphDomain.IsConnected(sourceVertexId, targetVertexId);
        }

        public List<int> GetOutNeighbors(int vertexId)
        {
            return this.GraphDomain.GetOutNeighbors(vertexId);
        }

        public List<int> GetInNeighbors(int vertexId)
        {
            return this.GraphDomain.GetInNeighbors(vertexId);
        }

        public int GetOutVertexDegree(int vertexId)
        {
            return this.GraphDomain.GetOutVertexDegree(vertexId);
        }

        public int GetInVertexDegree(int vertexId)
        {
            return this.GraphDomain.GetInVertexDegree(vertexId);
        }

        public bool IsComplete()
        {
            return this.GraphDomain.IsComplete();
        }

        public bool IsRegular()
        {
            return this.GraphDomain.IsRegular();
        }

        public bool IsConnectedGraph()
        {
            return this.GraphDomain.IsConnectedGraph();
        }

        public bool IsStronglyConnected()
        {
            return this.GraphDomain.IsStronglyConnected();
        }

        public bool IsWeaklyConnected()
        {
            return this.GraphDomain.IsWeaklyConnected();
        }

        public bool IsEulerian()
        {
            return this.GraphDomain.IsEulerian();
        }

        public bool IsAcyclic()
        {
            return this.GraphDomain.IsAcyclic();
        }

        public HashSet<int> DepthFirstSearch(int sourceVertexId)
        {
            HashSet<int> visited = new HashSet<int>();
            this.GraphDomain.DepthFirstSearch(sourceVertexId, visited);
            return visited;
        }

        public List<int> BreadthFirstSearch(int sourceVertexId)
        {
            return this.GraphDomain.BreadthFirstSearch(sourceVertexId);
        }

        public Dictionary<int, int> Dijkstra(int sourceVertexId)
        {
            return this.GraphDomain.Dijkstra(sourceVertexId);
        }

        public int[,] FloydWarshall()
        {
            return this.GraphDomain.FloydWarshall();
        }
    }
}
