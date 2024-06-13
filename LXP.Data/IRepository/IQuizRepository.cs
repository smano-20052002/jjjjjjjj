using LXP.Common.Entities;
using LXP.Common.ViewModels.QuizViewModel;

namespace LXP.Data.IRepository
{
    public interface IQuizRepository
    {
        Quiz GetQuizById(Guid quizId);
        IEnumerable<Quiz> GetAllQuizzes();
        void AddQuiz(Quiz quiz);
        void UpdateQuiz(Quiz quiz);
        void DeleteQuiz(Quiz quiz);
        Topic GetTopicById(Guid topicId);
        Quiz GetQuizByTopicId(Guid topicId);

        //

        IEnumerable<Quizfeedbackquestion> GetQuizFeedbackQuestionsByQuizId(Guid quizId);


        //new

        IEnumerable<LearnerAttempt> GetLearnerAttemptsByQuizId(Guid quizId);
        void DeleteLearnerAttempt(LearnerAttempt attempt);
    }
}
