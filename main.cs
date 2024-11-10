using System;
using System.Diagnostics;
using GraphModels.Models;

namespace GraphApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira o número de vértices: ");
            int numVertices;
            while (!int.TryParse(Console.ReadLine(), out numVertices) || numVertices <= 0)
            {
                Console.WriteLine("Por favor, insira um número inteiro positivo válido para o número de vértices.");
                Console.Write("Insira o número de vértices: ");
            }
            
            var graph = new Graph(numVertices);
            var vertices = new Vertex[numVertices];

            var defaultWeight = 1;
            for (int i = 0; i < numVertices; i++)
            {
                var value = ((char)('A' + i)).ToString();
                var vertex = new Vertex(i + 1, value, defaultWeight, value);
                graph.AddVertex(vertex);
                vertices[i] = vertex;
            }

            while (true)
            {
                Console.WriteLine("\nVocê gostaria de:");
                Console.WriteLine("\n (1) Adicionar uma aresta?");
                Console.WriteLine("\n (2) Remover uma aresta?");
                Console.WriteLine("\n (3) Adicionar um rótulo ao vértice?");
                Console.WriteLine("\n (4) Adicionar peso ao vértice?");
                Console.WriteLine("\n (5) Adicionar rótulo à aresta?");
                Console.WriteLine("\n (6) Adicionar peso à aresta?");
                Console.WriteLine("\n");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        AddEdge(graph);
                        break;
                    case "2":
                        RemoveEdge(graph);
                        break;
                    case "3":
                        AddVertexLabel(graph);
                        break;
                    case "4":
                        AddVertexWeight(graph);
                        break;
                    case "5":
                        AddEdgeLabel(graph);
                        break;
                    case "6":
                        AddEdgeWeight(graph);
                        break;
                    default:
                        // Não fazer nada
                        break;
                }

                graph.PrintAdjacencyMatrix();
                graph.PrintAdjacencyList();
            }
        }

        static void AddEdge(Graph graph)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetId = int.Parse(Console.ReadLine());

            Console.Write("Insira o peso: ");
            int weight = int.Parse(Console.ReadLine());

            graph.Connect(sourceId, targetId, weight);
        }

        static void RemoveEdge(Graph graph)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetId = int.Parse(Console.ReadLine());

            graph.Disconnect(sourceId, targetId);
        }

        static void AddVertexLabel(Graph graph)
        {
            Console.Write("Insira o ID do vértice: ");
            int vertexId = int.Parse(Console.ReadLine());
            var vertex = graph.GetVertexById(vertexId);

            if (vertex != null)
            {
                Console.Write("Insira o rótulo do vértice: ");
                string label = Console.ReadLine();

                vertex.SetLabel(label);
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        static void AddVertexWeight(Graph graph)
        {
            Console.Write("Insira o ID do vértice: ");
            int vertexId = int.Parse(Console.ReadLine());
            var vertex = graph.GetVertexById(vertexId);

            if (vertex != null)
            {
                Console.Write("Insira o peso do vértice: ");
                int weight = int.Parse(Console.ReadLine());

                vertex.SetWeight(weight);
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        static void AddEdgeLabel(Graph graph)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var edge = graph.GetEdgeByIdentifier(edgeIdentifier);

            if (edge != null)
            {
                Console.Write("Insira o rótulo da aresta: ");
                string label = Console.ReadLine();

                edge.SetLabel(label);
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }

        static void AddEdgeWeight(Graph graph)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var edge = graph.GetEdgeByIdentifier(edgeIdentifier);

            if (edge != null)
            {
                Console.Write("Insira o peso da aresta: ");
                int weight = int.Parse(Console.ReadLine());

                edge.SetWeight(weight);
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }
    }
}
