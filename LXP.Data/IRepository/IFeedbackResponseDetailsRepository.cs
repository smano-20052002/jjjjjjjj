using LXP.Common.Entities;
using LXP.Common.ViewModels.FeedbackResponseViewModel;
using LXP.Data.IRepository;

namespace LXP.Data.IRepository
{
    public interface IFeedbackResponseDetailsRepository
    {
        List<QuizFeedbackResponseDetailsViewModel> GetQuizFeedbackResponses(Guid quizId);
        List<TopicFeedbackResponseDetailsViewModel> GetTopicFeedbackResponses(Guid topicId);
        List<QuizFeedbackResponseDetailsViewModel> GetQuizFeedbackResponsesByLearner(
            Guid quizId,
            Guid learnerId
        );
        List<TopicFeedbackResponseDetailsViewModel> GetTopicFeedbackResponsesByLearner(
            Guid topicId,
            Guid learnerId
        );

        List<QuizFeedbackResponseDetailsViewModel> GetAllQuizFeedbackResponses();
        List<TopicFeedbackResponseDetailsViewModel> GetAllTopicFeedbackResponses();
    }
}
