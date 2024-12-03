using System;

namespace GraphInCSharp.Domain.Representations
{
    public class AdjacencyMatrix
    {
        private int[,] adjacencyMatrix;

        public AdjacencyMatrix(int numVertices)
        {
            this.adjacencyMatrix = new int[numVertices, numVertices];
        }

        public void Connect(int sourceVertexId, int targetVertexId, int weight)
        {
            this.adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = weight;
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            this.adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = 0;
        }

        public int GetLength(int dimension)
        {
            return this.adjacencyMatrix.GetLength(dimension);
        }

        public int GetValue(int sourceVertexId, int targetVertexId)
        {
            return this.adjacencyMatrix[sourceVertexId, targetVertexId];
        }

        public bool IsConnected(int sourceVertexId, int targetVertexId)
        {
            int? weight = this.adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1];
            if (weight != null && weight != 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
