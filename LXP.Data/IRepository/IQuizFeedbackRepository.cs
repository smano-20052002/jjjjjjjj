using LXP.Common.Entities;
using LXP.Common.ViewModels.QuizFeedbackQuestionViewModel;

namespace LXP.Data.IRepository
{
    public interface IQuizFeedbackRepository
    {
        void AddFeedbackQuestion(Quizfeedbackquestion questionEntity);
        void AddFeedbackQuestionOptions(List<Feedbackquestionsoption> options);
        List<QuizfeedbackquestionNoViewModel> GetAllFeedbackQuestions();
        List<QuizfeedbackquestionNoViewModel> GetFeedbackQuestionsByQuizId(Guid quizId);
        int GetNextFeedbackQuestionNo(Guid quizId);
        Quizfeedbackquestion GetFeedbackQuestionEntityById(Guid quizFeedbackQuestionId);
        void UpdateFeedbackQuestion(Quizfeedbackquestion questionEntity);
        void DeleteFeedbackQuestion(Quizfeedbackquestion questionEntity);
        List<Feedbackquestionsoption> GetFeedbackQuestionOptions(Guid quizFeedbackQuestionId);
        void DeleteFeedbackQuestionOptions(List<Feedbackquestionsoption> options);
        void DeleteFeedbackResponses(List<Feedbackresponse> responses);
        List<Feedbackresponse> GetFeedbackResponsesByQuestionId(Guid quizFeedbackQuestionId);
    }
}
