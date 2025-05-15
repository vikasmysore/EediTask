namespace Domain.Entities
{
    public class Topic
    {
        public int Id { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing
        public string Name { get; set; }

        public List<SubTopic> SubTopics { get; set; } = new();
    }
}
