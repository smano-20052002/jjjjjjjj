namespace LXP.Common.ViewModels
{
    public class LearnerFeedbackViewModel
    {
        public Guid LearnerId { get; set; }
        public Guid QuizId { get; set; }
        public Guid TopicId { get; set; }
        public bool IsQuizFeedbackGiven { get; set; }
        public bool IsTopicFeedbackGiven { get; set; }
    }
}
