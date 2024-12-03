namespace GraphInCSharp.Domain.Models
{
    public class Edge
    {
        public int Source { get; set; }
        public int Target { get; set; }
        public int Weight { get; set; }
        public string Label { get; set; }

        public Edge(int source, int target, int weight, string label = "")
        {
            Source = source;
            Target = target;
            Weight = weight;
            Label = label;
        }
    }
}
