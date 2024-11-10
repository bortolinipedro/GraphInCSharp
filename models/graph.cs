using System;
using System.Collections.Generic;

namespace GraphModels.Models
{
    public class Graph
    {
        // Matriz
        private int[,] adjacencyMatrix;

        // Lista de adjacência
        private Dictionary<int, List<int>> adjacencyList;

        public Graph(int numVertices)
        {
            adjacencyMatrix = new int[numVertices, numVertices];

            adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddVertex(Vertex vertex)
        {
            adjacencyList[vertex.GetId()] = new List<int>();
        }

        public void Connect(int sourceVertexId, int targetVertexId)
        {
            adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = 1;
        
            adjacencyList[sourceVertexId].Add(targetVertexId);
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
            foreach (var vertex in adjacencyList)
            {
                Console.Write(vertex.Key + ": ");
                foreach (var adjacentVertex in vertex.Value)
                {
                    Console.Write(adjacentVertex + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
