using LXP.Common.Entities;
using LXP.Data.IRepository;

namespace LXP.Data.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly LXPDbContext _LXPDbContext;

        public QuizRepository(LXPDbContext dbContext)
        {
            _LXPDbContext = dbContext;
        }

        public void AddQuiz(Quiz quiz)
        {
            _LXPDbContext.Quizzes.Add(quiz);
            _LXPDbContext.SaveChanges();
        }

        public Quiz GetQuizById(Guid quizId)
        {
            return _LXPDbContext.Quizzes.Find(quizId);
        }

        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return _LXPDbContext.Quizzes.ToList();
        }

        public void UpdateQuiz(Quiz quiz)
        {
            _LXPDbContext.Quizzes.Update(quiz);
            _LXPDbContext.SaveChanges();
        }

        public void DeleteQuiz(Quiz quiz)
        {
            _LXPDbContext.Quizzes.Remove(quiz);
            _LXPDbContext.SaveChanges();
        }

        public Topic GetTopicById(Guid topicId)
        {
            return _LXPDbContext.Topics.FirstOrDefault(t => t.TopicId == topicId);
        }

        public Quiz GetQuizByTopicId(Guid topicId)
        {
            return _LXPDbContext.Quizzes.FirstOrDefault(q => q.TopicId == topicId);
        }


        //
        public IEnumerable<Quizfeedbackquestion> GetQuizFeedbackQuestionsByQuizId(Guid quizId)
        {
            return _LXPDbContext.Quizfeedbackquestions.Where(q => q.QuizId == quizId).ToList();
        }

        //new 


        public IEnumerable<LearnerAttempt> GetLearnerAttemptsByQuizId(Guid quizId)
        {
            return _LXPDbContext.LearnerAttempts.Where(a => a.QuizId == quizId).ToList();
        }

        public void DeleteLearnerAttempt(LearnerAttempt attempt)
        {
            var learnerAnswers = _LXPDbContext.LearnerAnswers.Where(a => a.LearnerAttemptId == attempt.LearnerAttemptId);
            _LXPDbContext.LearnerAnswers.RemoveRange(learnerAnswers);

            _LXPDbContext.LearnerAttempts.Remove(attempt);
            _LXPDbContext.SaveChanges();
        }


    }
}
