namespace GraphModels.Models
{
    public class Vertex
    {
        public int Id { get; private set; }
        public object Value { get; private set; }
        public int Weight { get; private set; }
        public string Label { get; private set; }

        public Vertex(int id, object value, int weight, string label)
        {
            Id = id;
            Value = value;
            Weight = weight;
            Label = label;
        }

        public int GetId()
        {
            return Id;
        }

        public object GetValue()
        {
            return Value;
        }

        public int? GetWeight()
        {
            return Weight;
        }

        public void SetWeight(int weight)
        {
            Weight = weight;
        }

        public void SetLabel(string label)
        {
            Label = label;
        }

        public string GetLabel()
        {
            return Label;
        }
    }
}
