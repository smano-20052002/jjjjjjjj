using LXP.Common.ViewModels;

namespace LXP.Core.IServices
{
    public interface ILearnerDashboardService
    {
        public LearnerDashboardCourseCountViewModel GetLearnerDashboardDetails(Guid learnerId);
    }
}
