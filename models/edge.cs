using System;

namespace GraphModels.Models
{
    public class Edge
    {
        public int Source { get; private set; }
        public int Target { get; private set; }
        public int Weight { get; private set; }
        public string Label { get; private set; }

        public Edge(int source, int target, int weight, string label = "")
        {
            Source = source;
            Target = target;
            Weight = weight;
            Label = label;
        }

        public int GetSource()
        {
            return Source;
        }

        public int GetTarget()
        {
            return Target;
        }

        public int? GetWeight()
        {
            return Weight;
        }

        public string GetLabel()
        {
            return Label;
        }

        public void SetWeight(int weight)
        {
            Weight = weight;
        }

        public void SetLabel(string label)
        {
            Label = label;
        }
    }
}
