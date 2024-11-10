using System;
using System.Collections.Generic;

namespace GraphModels.Models
{
    public class Graph
    {
        public Dictionary<string, Edge> EdgeList { get; private set; }
        public Dictionary<int, Vertex> VertexList { get; private set; }

        // Matriz
        private int[,] adjacencyMatrix;

        // Lista de adjacência
        private Dictionary<int, List<int>> adjacencyList;

        public Graph(int numVertices)
        {
            EdgeList = new Dictionary<string, Edge>();
            VertexList = new Dictionary<int, Vertex>();

            adjacencyMatrix = new int[numVertices, numVertices];

            adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddVertex(Vertex vertex)
        {
            VertexList[vertex.GetId()] = vertex;

            adjacencyList[vertex.GetId()] = new List<int>();
        }

        public void Connect(int sourceVertexId, int targetVertexId, int weight)
        {
            Edge edge = new Edge(sourceVertexId, targetVertexId, weight);

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            EdgeList.Add(edgeIdentifier, edge);

            adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = weight;
        
            adjacencyList[sourceVertexId].Add(targetVertexId);
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            EdgeList.Remove(edgeIdentifier);

            adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = 0;

            adjacencyList[sourceVertexId].Remove(targetVertexId);
        }

        public Vertex GetVertexById(int id)
        {
            return VertexList[id];
        }

        public Edge GetVertexByIdentifier(string identifier)
        {
            return EdgeList[identifier];
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Lista de Adjacência:");
            foreach (var vertexAdjacency in adjacencyList)
            {
                var vertex = this.GetVertexById(vertexAdjacency.Key);
                Console.Write("{" + vertex.GetLabel() + " - " + vertex.GetWeight() + "}" + ": ");
                foreach (var adjacentVertex in vertexAdjacency.Value)
                {
                    Console.Write(adjacentVertex + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
