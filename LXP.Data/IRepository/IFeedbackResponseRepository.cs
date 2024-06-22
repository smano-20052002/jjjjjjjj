using LXP.Common.Entities;

namespace LXP.Data.IRepository
{
    public interface IFeedbackResponseRepository
    {
        Quizfeedbackquestion GetQuizFeedbackQuestion(Guid quizFeedbackQuestionId);
        Topicfeedbackquestion GetTopicFeedbackQuestion(Guid topicFeedbackQuestionId);
        Learner GetLearner(Guid learnerId);
        Feedbackresponse GetExistingQuizFeedbackResponse(
            Guid quizFeedbackQuestionId,
            Guid learnerId
        );
        Feedbackresponse GetExistingTopicFeedbackResponse(
            Guid topicFeedbackQuestionId,
            Guid learnerId
        );
        void AddFeedbackResponse(Feedbackresponse feedbackResponse);
        Guid? GetOptionIdByText(Guid questionId, string optionText);

        //new bug fix
        void DeleteFeedbackResponsesByQuizQuestionId(Guid quizFeedbackQuestionId);
        void DeleteFeedbackResponsesByTopicQuestionId(Guid topicFeedbackQuestionId);

        //LearnerProfile GetLearnerProfile(Guid learnerId);


        //new 


        IEnumerable<Quizfeedbackquestion> GetQuizFeedbackQuestions(Guid quizId);
        IEnumerable<Feedbackresponse> GetQuizFeedbackResponsesByLearner(Guid learnerId, Guid quizId);
        IEnumerable<Topicfeedbackquestion> GetTopicFeedbackQuestions(Guid topicId);
        IEnumerable<Feedbackresponse> GetTopicFeedbackResponsesByLearner(Guid learnerId, Guid topicId);



    }
}
















//using LXP.Common.ViewModels.FeedbackResponseViewModel;

//namespace LXP.Data.IRepository
//{
//    public interface IFeedbackResponseRepository
//    {
//        void SubmitFeedbackResponse(QuizFeedbackResponseViewModel feedbackResponse);
//        void SubmitFeedbackResponse(TopicFeedbackResponseViewModel feedbackResponse);
//    }
//}
