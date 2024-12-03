using System;
using System.Collections.Generic;
using GraphInCSharp.Application;
using GraphInCSharp.Domain.Models;

namespace GraphInCSharp.Controller
{
    public class GraphController
    {
        private GraphApplication GraphApplication;

        public GraphController() {
            this.GraphApplication = new GraphApplication();
        }

        public Graph CreateGraph(int numVertices)
        {
            return this.GraphApplication.CreateGraph(numVertices);
        }

        public void AddVertex(Vertex vertex)
        {
            this.GraphApplication.AddVertex(vertex);
        }

        public void Connect(int sourceVertexId, int targetVertexId, int weight)
        {
            this.GraphApplication.Connect(sourceVertexId, targetVertexId, weight);
        }

        public void AddEdgeWeight(int sourceVertexId, int targetVertexId, int weight)
        {
            this.GraphApplication.AddEdgeWeight(sourceVertexId, targetVertexId, weight);
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            this.GraphApplication.Disconnect(sourceVertexId, targetVertexId);
        }

        public Vertex GetVertexById(int id)
        {
            return this.GraphApplication.GetVertexById(id);
        }

        public Edge GetEdgeByIdentifier(string identifier)
        {
            return this.GraphApplication.GetEdgeByIdentifier(identifier);
        }

        public void PrintAdjacencyMatrix()
        {
            this.GraphApplication.PrintAdjacencyMatrix();
        }

        public void PrintAdjacencyList()
        {
            this.GraphApplication.PrintAdjacencyList();
        }

        public bool IsConnected(int sourceVertexId, int targetVertexId)
        {
            return this.GraphApplication.IsConnected(sourceVertexId, targetVertexId);
        }

        public List<int> GetOutNeighbors(int vertexId)
        {
            return this.GraphApplication.GetOutNeighbors(vertexId);
        }

        public List<int> GetInNeighbors(int vertexId)
        {
            return this.GraphApplication.GetInNeighbors(vertexId);
        }

        public int GetOutVertexDegree(int vertexId)
        {
            return this.GraphApplication.GetOutVertexDegree(vertexId);
        }

        public int GetInVertexDegree(int vertexId)
        {
            return this.GraphApplication.GetInVertexDegree(vertexId);
        }

        public bool IsComplete()
        {
            return this.GraphApplication.IsComplete();
        }

        public bool IsRegular()
        {
            return this.GraphApplication.IsRegular();
        }

        public bool IsConnectedGraph()
        {
            return this.GraphApplication.IsConnectedGraph();
        }

        public bool IsStronglyConnected()
        {
            return this.GraphApplication.IsStronglyConnected();
        }

        public bool IsWeaklyConnected()
        {
            return this.GraphApplication.IsWeaklyConnected();
        }

        public bool IsEulerian()
        {
            return this.GraphApplication.IsEulerian();
        }

        public bool IsAcyclic()
        {
            return this.GraphApplication.IsAcyclic();
        }

        public HashSet<int> DepthFirstSearch(int sourceVertexId)
        {
            return this.GraphApplication.DepthFirstSearch(sourceVertexId);
        }

        public List<int> BreadthFirstSearch(int sourceVertexId)
        {
            return this.GraphApplication.BreadthFirstSearch(sourceVertexId);
        }

        public Dictionary<int, int> Dijkstra(int sourceVertexId)
        {
            return this.GraphApplication.Dijkstra(sourceVertexId);
        }

        public int[,] FloydWarshall()
        {
            return this.GraphApplication.FloydWarshall();
        }
    }
}
