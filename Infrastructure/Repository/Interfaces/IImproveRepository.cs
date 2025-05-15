using Domain.Entities;

namespace Infrastructure.Repository.Interfaces
{
    public interface IImproveRepository
    {
        Task<IEnumerable<SubTopic>> GetSubTopicsWithIncorrectAnswersAsync(int studentId);
        Task<IEnumerable<Question>> GetIncorrectQuestionsForSubTopicAsync(int studentId, int subTopicId);
        Task UpdateAnswerAsync(int answerId, string newAnswer);
    }
}
