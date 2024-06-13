using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
