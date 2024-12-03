using System;
using System.Collections.Generic;
using GraphInCSharp.Domain.Models;

namespace GraphInCSharp.Domain.Representations
{
    public class AdjacencyList
    {
        private Dictionary<int, List<int>> adjacencyList;

        public AdjacencyList()
        {
            this.adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddVertex(Vertex vertex)
        {
            this.adjacencyList[vertex.Id] = new List<int>();
        }

        public void Connect(int sourceVertexId, int targetVertexId)
        {
            this.adjacencyList[sourceVertexId].Add(targetVertexId);
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            List<int> adjacencyList = this.adjacencyList[sourceVertexId];
            adjacencyList.Remove(targetVertexId);
        }

        public Dictionary<int, List<int>> GetList()
        {
            return this.adjacencyList;
        }

        public List<int> GetOutNeighbors(int sourceVertexId)
        {
            return this.adjacencyList[sourceVertexId];
        }
        
        public List<int> GetInNeighbors(int sourceVertexId)
        {
            List<int> inNeighbors = new List<int>();

            foreach (var vertex in this.adjacencyList.Keys)
            {
                if (this.GetOutNeighbors(vertex).Contains(sourceVertexId))
                    inNeighbors.Add(vertex);
            }

            return inNeighbors;
        }
    }
}
