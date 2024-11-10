namespace GraphModels.Models
{
    public class Vertex
    {
        public int Id { get; private set; }
        public object Value { get; private set; }

        public Vertex(int id, object value)
        {
            Id = id;
            Value = value;
        }

        public int GetId()
        {
            return Id;
        }

        public object GetValue()
        {
            return Value;
        }
    }
}
