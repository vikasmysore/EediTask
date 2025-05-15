namespace Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing
        public int StudentId { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing
        public int QuestionId { get; set; } // I prefer this to be a GUID but kept it intger for simplicity and manual testing

        public string GivenAnswer { get; set; }
        public bool IsCorrect { get; set; }

        public Student Student { get; set; }
        public Question Question { get; set; }
    }
}
