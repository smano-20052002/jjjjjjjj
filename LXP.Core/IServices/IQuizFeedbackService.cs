using LXP.Common.ViewModels.QuizFeedbackQuestionViewModel;

namespace LXP.Core.IServices
{
    public interface IQuizFeedbackService
    {
        Guid AddFeedbackQuestion(
            QuizfeedbackquestionViewModel quizfeedbackquestion,
            List<QuizFeedbackQuestionsOptionViewModel> options
        );

        List<QuizfeedbackquestionNoViewModel> GetAllFeedbackQuestions();

        QuizfeedbackquestionNoViewModel GetFeedbackQuestionById(Guid QuizFeedbackQuestionId);

        bool UpdateFeedbackQuestion(
            Guid quizFeedbackQuestionId,
            QuizfeedbackquestionViewModel quizfeedbackquestion,
            List<QuizFeedbackQuestionsOptionViewModel> options
        );

        bool DeleteFeedbackQuestion(Guid quizFeedbackQuestionId);
        List<QuizfeedbackquestionNoViewModel> GetFeedbackQuestionsByQuizId(Guid quizId);
        bool DeleteFeedbackQuestionsByQuizId(Guid quizId);
    }
}
