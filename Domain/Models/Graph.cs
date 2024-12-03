using System;
using System.Collections.Generic;
using GraphInCSharp.Domain.Representations;

namespace GraphInCSharp.Domain.Models
{
    public class Graph
    {
        public Dictionary<string, Edge> EdgeList { get; set; }
        public Dictionary<int, Vertex> VertexList { get; set; }
        public AdjacencyMatrix AdjacencyMatrix { get; set; }
        public AdjacencyList AdjacencyList { get; set; }

        public Graph(int numVertices)
        {
            this.EdgeList = new Dictionary<string, Edge>();
            this.VertexList = new Dictionary<int, Vertex>();
            this.AdjacencyMatrix = new AdjacencyMatrix(numVertices);
            this.AdjacencyList = new AdjacencyList();
        }
    }
}
