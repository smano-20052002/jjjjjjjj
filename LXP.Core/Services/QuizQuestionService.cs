

using LXP.Common.ViewModels.QuizQuestionViewModel;
using LXP.Core.IServices;
using LXP.Data.IRepository;

namespace LXP.Core.Services
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private readonly IQuizQuestionRepository _quizQuestionRepository;

        public QuizQuestionService(IQuizQuestionRepository quizQuestionRepository)
        {
            _quizQuestionRepository = quizQuestionRepository;
        }

        public async Task<Guid> AddQuestionAsync(
            QuizQuestionViewModel quizQuestion,
            List<QuestionOptionViewModel> options
        )
        {
            return await _quizQuestionRepository.AddQuestionAsync(quizQuestion, options);
        }

        public async Task<bool> UpdateQuestionAsync(
            Guid quizQuestionId,
            QuizQuestionViewModel quizQuestion,
            List<QuestionOptionViewModel> options
        )
        {
            return await _quizQuestionRepository.UpdateQuestionAsync(
                quizQuestionId,
                quizQuestion,
                options
            );
        }

        public async Task<bool> DeleteQuestionAsync(Guid quizQuestionId)
        {
            return await _quizQuestionRepository.DeleteQuestionAsync(quizQuestionId);
        }

        public async Task<List<QuizQuestionNoViewModel>> GetAllQuestionsAsync()
        {
            return await _quizQuestionRepository.GetAllQuestionsAsync();
        }

        public async Task<List<QuizQuestionNoViewModel>> GetAllQuestionsByQuizIdAsync(Guid quizId)
        {
            return await _quizQuestionRepository.GetAllQuestionsByQuizIdAsync(quizId);
        }

        public async Task<QuizQuestionNoViewModel> GetQuestionByIdAsync(Guid quizQuestionId)
        {
            return await _quizQuestionRepository.GetQuestionByIdAsync(quizQuestionId);
        }
    }
}
