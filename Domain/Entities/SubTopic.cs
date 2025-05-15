using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class SubTopic
    {
        public int Id { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing
        public string Name { get; set; }

        public int TopicId { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing

        [JsonIgnore]
        public Topic Topic { get; set; }

        public List<Question> Questions { get; set; } = new();
    }
}
