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
            if (!VertexList.ContainsKey(id)) {
                return null;
            }

            return VertexList[id];
        }

        public Edge GetEdgeByIdentifier(string identifier)
        {
            if (!EdgeList.ContainsKey(identifier)) {
                return null;
            }

            return EdgeList[identifier];
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int sourcePosition = 0; sourcePosition < adjacencyMatrix.GetLength(0); sourcePosition++)
            {
                for (int targetPosition = 0; targetPosition < adjacencyMatrix.GetLength(1); targetPosition++)
                {
                    var edgeIdentifier = (sourcePosition + 1) + "_" + (targetPosition + 1);
                    var edge = this.GetEdgeByIdentifier(edgeIdentifier);
                    
                    if (edge != null) {
                        Console.Write("{" + edge.GetLabel() + " - " + edge.GetWeight() + "}" + " ");
                    } else {
                        Console.Write(adjacencyMatrix[sourcePosition, targetPosition] + " ");
                    }
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
                if (vertex != null) {
                    Console.Write("{" + vertex.GetLabel() + " - " + vertex.GetWeight() + "}" + ": ");
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
    }
}
