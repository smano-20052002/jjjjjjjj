

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


//working code before converting into arch standards


//using LXP.Common.ViewModels.QuizFeedbackQuestionViewModel;

//namespace LXP.Data.IRepository
//{
//    public interface IQuizFeedbackRepository
//    {
//        Guid AddFeedbackQuestion(
//            QuizfeedbackquestionViewModel quizfeedbackquestion,
//            List<QuizFeedbackQuestionsOptionViewModel> options
//        );
//        List<QuizfeedbackquestionNoViewModel> GetAllFeedbackQuestions();
//        int GetNextFeedbackQuestionNo(Guid quizId);
//        Guid AddFeedbackQuestionOption(
//            QuizFeedbackQuestionsOptionViewModel feedbackquestionsoption,
//            Guid QuizFeedbackQuestionId
//        );
//        List<QuizFeedbackQuestionsOptionViewModel> GetFeedbackQuestionOptionsById(
//            Guid QuizFeedbackQuestionId
//        );
//        QuizfeedbackquestionNoViewModel GetFeedbackQuestionById(Guid QuizFeedbackQuestionId);
//        bool ValidateOptionsByFeedbackQuestionType(
//            string questionType,
//            List<QuizFeedbackQuestionsOptionViewModel> options
//        );
//        bool UpdateFeedbackQuestion(
//            Guid QuizFeedbackQuestionId,
//            QuizfeedbackquestionViewModel quizfeedbackquestion,
//            List<QuizFeedbackQuestionsOptionViewModel> options
//        );
//        bool DeleteFeedbackQuestion(Guid QuizFeedbackQuestionId);
//        List<QuizfeedbackquestionNoViewModel> GetFeedbackQuestionsByQuizId(Guid quizId);
//        bool DeleteFeedbackQuestionsByQuizId(Guid quizId);
//    }
//}