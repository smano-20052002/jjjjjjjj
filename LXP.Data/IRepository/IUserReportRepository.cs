using LXP.Common.ViewModels;

namespace LXP.Data.IRepository
{
    public interface IUserReportRepository
    {
        IEnumerable<UserReportViewModel> GetUserReport();
    }
}
