using LXP.Common.ViewModels.FeedbackResponseViewModel;
using LXP.Data.IRepository;
using LXP.Data.Repository;
using LXP.Services.IServices;

namespace LXP.Services
{
    public class FeedbackResponseDetailsService : IFeedbackResponseDetailsService
    {
        private readonly IFeedbackResponseDetailsRepository _feedbackResponseDetailsRepository;

        public FeedbackResponseDetailsService(
            IFeedbackResponseDetailsRepository feedbackResponseDetailsRepository
        )
        {
            _feedbackResponseDetailsRepository = feedbackResponseDetailsRepository;
        }

        public List<QuizFeedbackResponseDetailsViewModel> GetQuizFeedbackResponses(Guid quizId)
        {
            return _feedbackResponseDetailsRepository.GetQuizFeedbackResponses(quizId);
        }

        public List<TopicFeedbackResponseDetailsViewModel> GetTopicFeedbackResponses(Guid topicId)
        {
            return _feedbackResponseDetailsRepository.GetTopicFeedbackResponses(topicId);
        }

        public List<QuizFeedbackResponseDetailsViewModel> GetQuizFeedbackResponsesByLearner(
            Guid quizId,
            Guid learnerId
        )
        {
            return _feedbackResponseDetailsRepository.GetQuizFeedbackResponsesByLearner(
                quizId,
                learnerId
            );
        }

        public List<TopicFeedbackResponseDetailsViewModel> GetTopicFeedbackResponsesByLearner(
            Guid topicId,
            Guid learnerId
        )
        {
            return _feedbackResponseDetailsRepository.GetTopicFeedbackResponsesByLearner(
                topicId,
                learnerId
            );
        }

        public List<QuizFeedbackResponseDetailsViewModel> GetAllQuizFeedbackResponses()
        {
            return _feedbackResponseDetailsRepository.GetAllQuizFeedbackResponses();
        }

        public List<TopicFeedbackResponseDetailsViewModel> GetAllTopicFeedbackResponses()
        {
            return _feedbackResponseDetailsRepository.GetAllTopicFeedbackResponses();
        }
    }
}
