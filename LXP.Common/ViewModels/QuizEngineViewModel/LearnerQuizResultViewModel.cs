namespace LXP.Common.ViewModels.QuizEngineViewModel
{
    public class LearnerLastQuizResultViewModel
    {
        public bool IsLearnerPassed { get; set; }
        public bool HasAttemptsRemaining { get; set; }
        public Guid QuizId { get; set; }
        public string QuizName { get; set; }
    }
}


//new
