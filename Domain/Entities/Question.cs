namespace Domain.Entities
{
    public class Question
    {
        public int Id { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing
        public string Text { get; set; }

        public int SubTopicId { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing
        public SubTopic SubTopic { get; set; }
    }
}
