using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;

namespace Application.Services
{
    public class ImproveService : IImproveService
    {
        private readonly IImproveRepository _repository;

        public ImproveService(IImproveRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Question>> GetIncorrectQuestionsForSubTopicAsync(int studentId, int subTopicId)
        {
            return await _repository.GetIncorrectQuestionsForSubTopicAsync(studentId, subTopicId);
        }

        public async Task<IEnumerable<SubTopic>> GetSubTopicsWithIncorrectAnswersAsync(int studentId)
        {
            return await _repository.GetSubTopicsWithIncorrectAnswersAsync(studentId);
        }

        public async Task UpdateAnswerAsync(int answerId, string newAnswer)
        {
            await _repository.UpdateAnswerAsync(answerId, newAnswer);
        }
    }
}
