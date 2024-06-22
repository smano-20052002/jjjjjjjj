using LXP.Common.Entities;
using LXP.Data.IRepository;

namespace LXP.Data.Repository
{
    public class FeedbackResponseRepository : IFeedbackResponseRepository
    {
        private readonly LXPDbContext _context;

        public FeedbackResponseRepository(LXPDbContext context)
        {
            _context = context;
        }

        public Quizfeedbackquestion GetQuizFeedbackQuestion(Guid quizFeedbackQuestionId)
        {
            return _context.Quizfeedbackquestions.FirstOrDefault(q =>
                q.QuizFeedbackQuestionId == quizFeedbackQuestionId
            );
        }

        public Topicfeedbackquestion GetTopicFeedbackQuestion(Guid topicFeedbackQuestionId)
        {
            return _context.Topicfeedbackquestions.FirstOrDefault(q =>
                q.TopicFeedbackQuestionId == topicFeedbackQuestionId
            );
        }

        public Learner GetLearner(Guid learnerId)
        {
            return _context.Learners.FirstOrDefault(l => l.LearnerId == learnerId);
        }

        public Feedbackresponse GetExistingQuizFeedbackResponse(
            Guid quizFeedbackQuestionId,
            Guid learnerId
        )
        {
            return _context.Feedbackresponses.FirstOrDefault(r =>
                r.QuizFeedbackQuestionId == quizFeedbackQuestionId && r.LearnerId == learnerId
            );
        }

        public Feedbackresponse GetExistingTopicFeedbackResponse(
            Guid topicFeedbackQuestionId,
            Guid learnerId
        )
        {
            return _context.Feedbackresponses.FirstOrDefault(r =>
                r.TopicFeedbackQuestionId == topicFeedbackQuestionId && r.LearnerId == learnerId
            );
        }

        public void AddFeedbackResponse(Feedbackresponse feedbackResponse)
        {
            _context.Feedbackresponses.Add(feedbackResponse);
            _context.SaveChanges();
        }

        public void AddFeedbackResponses(IEnumerable<Feedbackresponse> feedbackResponses)
        {
            _context.Feedbackresponses.AddRange(feedbackResponses);
            _context.SaveChanges();
        }


        public Guid? GetOptionIdByText(Guid questionId, string optionText)
        {
            var option =
                _context.Feedbackquestionsoptions.FirstOrDefault(o =>
                    o.QuizFeedbackQuestionId == questionId
                    && o.OptionText.ToLower() == optionText.ToLower()
                )
                ?? _context.Feedbackquestionsoptions.FirstOrDefault(o =>
                    o.TopicFeedbackQuestionId == questionId
                    && o.OptionText.ToLower() == optionText.ToLower()
                );

            return option?.FeedbackQuestionOptionId;
        }

        //new bug fix
        public void DeleteFeedbackResponsesByQuizQuestionId(Guid quizFeedbackQuestionId)
        {
            var responses = _context
                .Feedbackresponses.Where(r => r.QuizFeedbackQuestionId == quizFeedbackQuestionId)
                .ToList();
            _context.Feedbackresponses.RemoveRange(responses);
            _context.SaveChanges();
        }

        public void DeleteFeedbackResponsesByTopicQuestionId(Guid topicFeedbackQuestionId)
        {
            var responses = _context
                .Feedbackresponses.Where(r => r.TopicFeedbackQuestionId == topicFeedbackQuestionId)
                .ToList();
            _context.Feedbackresponses.RemoveRange(responses);
            _context.SaveChanges();
        }



        // new 

        public IEnumerable<Quizfeedbackquestion> GetQuizFeedbackQuestions(Guid quizId)
        {
            return _context.Quizfeedbackquestions.Where(q => q.QuizId == quizId).ToList();
        }

        public IEnumerable<Feedbackresponse> GetQuizFeedbackResponsesByLearner(Guid learnerId, Guid quizId)
        {
            return _context.Feedbackresponses
                .Where(r => r.LearnerId == learnerId && r.QuizFeedbackQuestion.QuizId == quizId)
                .ToList();
        }

        public IEnumerable<Topicfeedbackquestion> GetTopicFeedbackQuestions(Guid topicId)
        {
            return _context.Topicfeedbackquestions.Where(q => q.TopicId == topicId).ToList();
        }

        public IEnumerable<Feedbackresponse> GetTopicFeedbackResponsesByLearner(Guid learnerId, Guid topicId)
        {
            return _context.Feedbackresponses
                .Where(r => r.LearnerId == learnerId && r.TopicFeedbackQuestion.TopicId == topicId)
                .ToList();
        }
    }
}

