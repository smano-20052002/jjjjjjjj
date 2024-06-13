using LXP.Common.Entities;

namespace LXP.Data.IRepository
{
    public interface IBulkQuestionRepository
    {
        Task<List<QuizQuestion>> AddQuestionsAsync(List<QuizQuestion> quizQuestions);
        Task AddOptionsAsync(List<QuestionOption> questionOptions, Guid quizQuestionId);

        Task<int> GetNextQuestionNoAsync(Guid quizId);
    }
}
