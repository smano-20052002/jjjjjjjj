using System.Collections.Generic;
using System.Threading.Tasks;
using LXP.Common.Entities;

namespace LXP.Data.IRepository
{
    public interface IQuizQuestionJsonRepository
    {
        Task<List<QuizQuestion>> AddQuestionsAsync(List<QuizQuestion> questions);
        Task AddOptionsAsync(List<QuestionOption> questionOptions, Guid quizQuestionId);
        Task<int> GetNextQuestionNoAsync(Guid quizId);
    }
}
