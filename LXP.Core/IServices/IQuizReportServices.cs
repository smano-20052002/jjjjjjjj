using LXP.Common.ViewModels;

namespace LXP.Core.IServices
{
    public interface IQuizReportServices
    {
        IEnumerable<QuizReportViewModel> GetQuizReports();
        IEnumerable<QuizScorelearnerViewModel> GetPassdLearnersList(Guid Quizid);
        IEnumerable<QuizScorelearnerViewModel> GetFailedLearnersList(Guid Quizid);
    }
}
