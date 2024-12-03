namespace GraphInCSharp.Domain.Models
{
    public class Vertex
    {
        public int Id { get; set; }
        public object Value { get; set; }
        public int Weight { get; set; }
        public string Label { get; set; }

        public Vertex(int id, object value, int weight, string label)
        {
            Id = id;
            Value = value;
            Weight = weight;
            Label = label;
        }
    }
}
