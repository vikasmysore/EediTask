using Domain.Entities;

namespace Application.Interfaces
{
    public interface IImproveService
    {
        Task<IEnumerable<SubTopic>> GetSubTopicsWithIncorrectAnswersAsync(int studentId);
        Task<IEnumerable<Question>> GetIncorrectQuestionsForSubTopicAsync(int studentId, int subTopicId);
        Task UpdateAnswerAsync(int answerId, string newAnswer);
    }
}
