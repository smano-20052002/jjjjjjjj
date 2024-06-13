using LXP.Common.ViewModels.QuizQuestionViewModel;
using Microsoft.AspNetCore.Http;

namespace LXP.Core.IServices
{
    public interface IExcelToJsonService
    {
        Task<List<QuizQuestionJsonViewModel>> ConvertExcelToJsonAsync(IFormFile file);
        Task SaveQuizDataAsync(List<QuizQuestionJsonViewModel> quizData, Guid quizId);
        List<QuizQuestionJsonViewModel> ValidateQuizData(List<QuizQuestionJsonViewModel> quizData);
    }
}
