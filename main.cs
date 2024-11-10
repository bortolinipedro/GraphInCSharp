using System;
using System.Diagnostics;
using GraphModels.Models;

namespace GraphApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            // Define o número de vértices
            int numVertices = 20;
            
            var graph = new Graph(numVertices);
            var vertices = new Vertex[numVertices];

            // Cria vértices e adiciona ao grafo
            for (int i = 0; i < numVertices; i++)
            {
                var vertex = new Vertex(i + 1, ((char)('A' + i)).ToString());
                graph.AddVertex(vertex);
                vertices[i] = vertex;
            }

            // Conecta cada vértice a todos os outros
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    graph.Connect(vertices[i].GetId(), vertices[j].GetId());
                }
            }

            graph.PrintAdjacencyMatrix();
            graph.PrintAdjacencyList();

            stopwatch.Stop();
            Console.WriteLine("Graph took {0}", stopwatch.Elapsed);
        }
    }
}
