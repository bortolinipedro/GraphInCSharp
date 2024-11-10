using System;

namespace GraphModels.Models
{
    public class Edge
    {
        public int Source { get; private set; }
        public int Target { get; private set; }

        public Edge(int source, int target)
        {
            Source = source;
            Target = target;
        }

        public int GetSource()
        {
            return Source;
        }

        public int GetTarget()
        {
            return Target;
        }
    }
}
