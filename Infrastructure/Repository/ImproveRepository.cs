using Domain.Entities;
using Infrastructure.DBContext;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ImproveRepository : IImproveRepository
    {
        private readonly AppDbContext _context;

        public ImproveRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetIncorrectQuestionsForSubTopicAsync(int studentId, int subTopicId)
        {
            return await _context.Answers
            .Include(a => a.Question)
            .Where(a => a.StudentId == studentId && !a.IsCorrect && a.Question.SubTopicId == subTopicId)
            .Select(a => a.Question)
            .ToListAsync();
        }

        public async Task<IEnumerable<SubTopic>> GetSubTopicsWithIncorrectAnswersAsync(int studentId)
        {
            var subTopicIds = await _context.Answers
            .Where(a => a.StudentId == studentId && !a.IsCorrect)
            .Select(a => a.Question.SubTopicId)
            .Distinct()
            .ToListAsync();

            var result = await _context.SubTopics
                .Include(st => st.Topic)
                .Where(st => subTopicIds.Contains(st.Id))
                .ToListAsync();
            return result;
        }

        public async Task UpdateAnswerAsync(int answerId, string newAnswer)
        {
            var answer = await _context.Answers
            .Include(a => a.Question)
            .FirstOrDefaultAsync(a => a.Id == answerId);

            if (answer == null) return;

            answer.GivenAnswer = newAnswer;
            answer.IsCorrect = newAnswer.Trim().ToLower() == "x=2"; // Placeholder logic

            await _context.SaveChangesAsync();
        }
    }
}
