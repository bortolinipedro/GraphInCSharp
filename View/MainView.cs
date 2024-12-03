using System;
using System.Collections.Generic;
using GraphInCSharp.Domain.Models;
using GraphInCSharp.Controller;

namespace GraphInCSharp.View
{
    public class MainView
    {
        private GraphController graphController;
        
        public void Exec()
        {
            this.graphController = new GraphController();

            Console.Write("Insira o número de vértices: ");
            int numVertices;
            while (!int.TryParse(Console.ReadLine(), out numVertices) || numVertices <= 0)
            {
                Console.WriteLine("Por favor, insira um número inteiro positivo válido para o número de vértices.");
                Console.Write("Insira o número de vértices: ");
            }
            
            this.graphController.CreateGraph(numVertices);

            var defaultWeight = 1;
            for (int i = 0; i < numVertices; i++)
            {
                var value = ((char)('A' + i)).ToString();
                var vertex = new Vertex(i + 1, value, defaultWeight, value);
                this.graphController.AddVertex(vertex);
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
                Console.WriteLine("\n (7) Verificar Adjacência entre vértices?");
                Console.WriteLine("\n (8) Verificar Vizinhança do vértice?");
                Console.WriteLine("\n (9) Verificar Grau do vértice?");
                Console.WriteLine("\n (10) Verificar Grafo completo?");
                Console.WriteLine("\n (11) Verificar Grafo Regular?");
                Console.WriteLine("\n (12) Verificar Grafo conexo?");
                Console.WriteLine("\n (13) Verificar Grafo acíclico?");
                Console.WriteLine("\n (14) Verificar Grafo Euleriano?");
                Console.WriteLine("\n (15) Realizar Busca em profundidade?");
                Console.WriteLine("\n (16) Realizar Busca em largura?");
                Console.WriteLine("\n (17) Calcular a menor distância de uma origem para todos os outros vértices (Usar Dijkstra)?");
                Console.WriteLine("\n (18) Calcular a menor distância de todos para todos. (usar Floyd-Warshall)?");
                Console.WriteLine("\n (19) Create a default one");
                Console.WriteLine("\n");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        this.AddEdge();
                        break;
                    case "2":
                        this.RemoveEdge();
                        break;
                    case "3":
                        this.AddVertexLabel();
                        break;
                    case "4":
                        this.AddVertexWeight();
                        break;
                    case "5":
                        this.AddEdgeLabel();
                        break;
                    case "6":
                        this.AddEdgeWeight();
                        break;
                    case "7":
                        this.IsConnected();
                        break;
                    case "8":
                        this.GetNeighbors();
                        break;
                    case "9":
                        this.GetVertexDegree();
                        break;
                    case "10":
                        this.IsComplete();
                        break;
                    case "11":
                        this.IsRegular();
                        break;
                    case "12":
                        this.IsConnectedGraph();
                        break;
                    case "13":
                        this.IsAcyclic();
                        break;
                    case "14":
                        this.IsEulerian();
                        break;
                    case "15":
                        this.DepthFirstSearch();
                        break;
                    case "16":
                        this.BreadthFirstSearch();
                        break;
                    case "17":
                        this.Dijkstra();
                        break;
                    case "18":
                        this.FloydWarshall();
                        break;
                    case "19":
                        this.CreateDefaultGraph();
                        break;
                    default:
                        // Do nothing
                        break;
                }

                Console.WriteLine("\n");
                this.graphController.PrintAdjacencyMatrix();
                Console.WriteLine("\n");
                this.graphController.PrintAdjacencyList();
            }
        }

        void AddEdge()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetId = int.Parse(Console.ReadLine());

            Console.Write("Insira o peso: ");
            int weight = int.Parse(Console.ReadLine());

            this.graphController.Connect(sourceId, targetId, weight);
        }

        void RemoveEdge()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetId = int.Parse(Console.ReadLine());

            this.graphController.Disconnect(sourceId, targetId);
        }

        void AddVertexLabel()
        {
            Console.Write("Insira o ID do vértice: ");
            int vertexId = int.Parse(Console.ReadLine());
            var vertex = this.graphController.GetVertexById(vertexId);

            if (vertex != null)
            {
                Console.Write("Insira o rótulo do vértice: ");
                string label = Console.ReadLine();

                vertex.Label = label;
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        void AddVertexWeight()
        {
            Console.Write("Insira o ID do vértice: ");
            int vertexId = int.Parse(Console.ReadLine());
            var vertex = this.graphController.GetVertexById(vertexId);

            if (vertex != null)
            {
                Console.Write("Insira o peso do vértice: ");
                int weight = int.Parse(Console.ReadLine());

                vertex.Weight = weight;
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        void AddEdgeLabel()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var edge = this.graphController.GetEdgeByIdentifier(edgeIdentifier);

            if (edge != null)
            {
                Console.Write("Insira o rótulo da aresta: ");
                string label = Console.ReadLine();

                edge.Label = label;
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }

        void AddEdgeWeight()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o peso da aresta: ");
            int weight = int.Parse(Console.ReadLine());

            this.graphController.AddEdgeWeight(sourceVertexId, targetVertexId, weight);
        }

        void IsConnected()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            if(this.graphController.IsConnected(sourceVertexId, targetVertexId)){
                Console.Write("Conectados");
            } else {
                Console.Write("Não conectados");
            }
        }

        void GetNeighbors()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            List<int> outNeighbors = this.graphController.GetOutNeighbors(sourceVertexId);
            List<int> inNeighbors = this.graphController.GetInNeighbors(sourceVertexId);
            
            Console.WriteLine("\n");
            Console.WriteLine("Out: " + string.Join(", ", outNeighbors));
            Console.WriteLine("In: " + string.Join(", ", inNeighbors));
        }

        void GetVertexDegree()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            int outDegree = this.graphController.GetOutVertexDegree(sourceVertexId);
            int inDegree = this.graphController.GetInVertexDegree(sourceVertexId);
            
            Console.WriteLine("\n");
            Console.WriteLine("Out: " + string.Join(", ", outDegree));
            Console.WriteLine("In: " + string.Join(", ", inDegree));
        }

        void IsComplete()
        {
            Console.WriteLine("\n");
            if(this.graphController.IsComplete()){
                Console.WriteLine("Completo");
            } else {
                Console.WriteLine("Não completo");
            }
        }

        void IsRegular()
        {
            Console.WriteLine("\n");
            if(this.graphController.IsRegular()){
                Console.WriteLine("Regular");
            } else {
                Console.WriteLine("Não regular");
            }
        }

        void IsConnectedGraph()
        {
            Console.WriteLine("\n");
            if (this.graphController.IsStronglyConnected())
            {
                Console.WriteLine("Fortemente conexo");
            }
            else if (this.graphController.IsWeaklyConnected())
            {
                Console.WriteLine("Fracamente conexo");
            } else {
                Console.WriteLine("Não conexo");
            }
        }

        void IsEulerian()
        {
            Console.WriteLine("\n");
            if(this.graphController.IsEulerian()){
                Console.WriteLine("Euleriano");
            } else {
                Console.WriteLine("Não euleriano");
            }
        }

        void IsAcyclic()
        {
            Console.WriteLine("\n");
            if(this.graphController.IsAcyclic()){
                Console.WriteLine("Acíclico");
            } else {
                Console.WriteLine("Não acíclico");
            }
        }

        void DepthFirstSearch()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            HashSet<int> result = this.graphController.DepthFirstSearch(sourceVertexId);

            Console.WriteLine("\n");
            Console.WriteLine("Result: " + string.Join(", ", result));
        }

        void BreadthFirstSearch()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            List<int> result = this.graphController.BreadthFirstSearch(sourceVertexId);
            
            Console.WriteLine("\n");
            Console.WriteLine("Result: " + string.Join(", ", result));
        }

        void Dijkstra()
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Dictionary<int, int> results = this.graphController.Dijkstra(sourceVertexId);
            
            Console.WriteLine("\n");
            foreach (var result in results)
            {
                Console.WriteLine("Key: " + result.Key + " Value: " + result.Value);
            }
        }

        void FloydWarshall()
        {
            int[,] result = this.graphController.FloydWarshall();

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        void CreateDefaultGraph()
        {
            var numVertices = 8;

            this.graphController = new GraphController();
            this.graphController.CreateGraph(numVertices);

            var defaultWeight = 1;
            for (int i = 0; i < numVertices; i++)
            {
                var value = ((char)('A' + i)).ToString();
                var vertex = new Vertex(i + 1, value, defaultWeight, value);
                this.graphController.AddVertex(vertex);
            }

            this.graphController.Connect(1, 2, 1);
            this.graphController.Connect(1, 3, 1);
            this.graphController.Connect(2, 6, 1);
            this.graphController.Connect(3, 5, 1);
            this.graphController.Connect(5, 6, 1);
            this.graphController.Connect(6, 7, 1);
            this.graphController.Connect(7, 8, -1);
            this.graphController.Connect(8, 1, 1);
        }
    }
}
