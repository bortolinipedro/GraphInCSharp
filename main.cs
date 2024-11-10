using System;
using System.Diagnostics;
using GraphModels.Models;

namespace GraphApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of vertices: ");
            int numVertices;
            while (!int.TryParse(Console.ReadLine(), out numVertices) || numVertices <= 0)
            {
                Console.WriteLine("Please enter a valid positive integer for the number of vertices.");
                Console.Write("Enter the number of vertices: ");
            }
            
            var graph = new Graph(numVertices);
            var vertices = new Vertex[numVertices];

            var defaultWeight = 1;
            for (int i = 0; i < numVertices; i++)
            {
                var vertex = new Vertex(i + 1, ((char)('A' + i)).ToString(), defaultWeight);
                graph.AddVertex(vertex);
                vertices[i] = vertex;
            }

            while (true)
            {
                Console.WriteLine("\nWould you like to: ");
                Console.WriteLine("\n (1) Add edge?");
                Console.WriteLine("\n (2) Remove edge?");
                Console.WriteLine("\n (3) Add vertex label?");
                Console.WriteLine("\n (4) Add vertex weight?");
                Console.WriteLine("\n (5) Add edge label?");
                Console.WriteLine("\n (6) Add edge weight?");
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
                        // Do nothing
                        break;
                }

                graph.PrintAdjacencyMatrix();
                graph.PrintAdjacencyList();
            }
        }


        static void AddEdge(Graph graph)
        {
            Console.Write("Enter source vertex ID: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Enter target vertex ID: ");
            int targetId = int.Parse(Console.ReadLine());

            Console.Write("Enter weight: ");
            int weight = int.Parse(Console.ReadLine());

            graph.Connect(sourceId, targetId, weight);
        }

        static void RemoveEdge(Graph graph)
        {
            Console.Write("Enter source vertex ID: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Enter target vertex ID: ");
            int targetId = int.Parse(Console.ReadLine());

            graph.Disconnect(sourceId, targetId);
        }

        static void AddVertexLabel(Graph graph)
        {
            Console.Write("Enter vertex ID: ");
            int vertexId = int.Parse(Console.ReadLine());
            var vertex = graph.GetVertexById(vertexId);

            if (vertex != null)
            {
                Console.Write("Enter vertex label: ");
                string label = Console.ReadLine();

                vertex.SetLabel(label);
            }
            else
            {
                Console.WriteLine("Vertex not found.");
            }
        }

        static void AddVertexWeight(Graph graph)
        {
            Console.Write("Enter vertex ID: ");
            int vertexId = int.Parse(Console.ReadLine());
            var vertex = graph.GetVertexById(vertexId);

            if (vertex != null)
            {
                Console.Write("Enter vertex weight: ");
                int weight = int.Parse(Console.ReadLine());

                vertex.SetWeight(weight);
            }
            else
            {
                Console.WriteLine("Vertex not found.");
            }
        }

        static void AddEdgeLabel(Graph graph)
        {
            Console.Write("Enter source vertex ID: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Enter target vertex ID: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var edge = graph.GetVertexByIdentifier(edgeIdentifier);

            if (edge != null)
            {
                Console.Write("Enter edge label: ");
                string label = Console.ReadLine();

                edge.SetLabel(label);
            }
            else
            {
                Console.WriteLine("Edge not found.");
            }
        }

        static void AddEdgeWeight(Graph graph)
        {
            Console.Write("Enter source vertex ID: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Enter target vertex ID: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var edge = graph.GetVertexByIdentifier(edgeIdentifier);

            if (edge != null)
            {
                Console.Write("Enter edge weight: ");
                int weight = int.Parse(Console.ReadLine());

                edge.SetWeight(weight);
            }
            else
            {
                Console.WriteLine("Edge not found.");
            }
        }
    }
}
