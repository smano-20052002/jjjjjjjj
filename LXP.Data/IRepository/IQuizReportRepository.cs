using LXP.Common.ViewModels;

namespace LXP.Data.IRepository
{
    public interface IQuizReportRepository
    {
        IEnumerable<QuizReportViewModel> GetQuizReports();
        IEnumerable<QuizScorelearnerViewModel> GetPassdLearnersList(Guid Quizid);
        IEnumerable<QuizScorelearnerViewModel> GetFailedLearnersList(Guid Quizid);
    }
}
