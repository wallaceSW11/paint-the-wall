using System.Text.Json.Serialization;

namespace paint_the_wall.src.Models
{
    public abstract class EntityBase
    {
        [JsonIgnore]
        public List<string> Messages { get; set; }

        public EntityBase()
        {
            Messages = new List<string>();
        }

        public void AddValidation(bool condition, string message)
        {
            if (condition) Messages.Add(message);
        }

        public string DescriptionInvalidModel()
        {
            return String.Join(", ", Messages.ToArray());
        }

        public bool ValidModel => Messages.Count() == 0;




    }
}