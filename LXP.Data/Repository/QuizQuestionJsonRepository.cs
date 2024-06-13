using LXP.Common.Entities;
using LXP.Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LXP.Core.Repositories
{
    public class QuizQuestionJsonRepository : IQuizQuestionJsonRepository
    {
        private readonly LXPDbContext _dbContext;

        public QuizQuestionJsonRepository(LXPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QuizQuestion>> AddQuestionsAsync(List<QuizQuestion> questions)
        {
            await _dbContext.QuizQuestions.AddRangeAsync(questions);
            await _dbContext.SaveChangesAsync();
            return questions;
        }

        public async Task AddOptionsAsync(List<QuestionOption> questionOptions, Guid quizQuestionId)
        {
            var existingQuestion = await _dbContext.QuizQuestions.FirstOrDefaultAsync(q =>
                q.QuizQuestionId == quizQuestionId
            );
            if (existingQuestion != null)
            {
                foreach (var option in questionOptions)
                {
                    option.QuizQuestionId = quizQuestionId;
                    _dbContext.QuestionOptions.Add(option);
                }
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Quiz question with ID {quizQuestionId} does not exist.");
            }
        }

        public async Task<int> GetNextQuestionNoAsync(Guid quizId)
        {
            try
            {
                int count = await _dbContext
                    .QuizQuestions.Where(q => q.QuizId == quizId)
                    .CountAsync();

                return count + 1;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "An error occurred while retrieving the next question number asynchronously.",
                    ex
                );
            }
        }
    }
}
