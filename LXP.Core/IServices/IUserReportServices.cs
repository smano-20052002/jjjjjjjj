using LXP.Common.ViewModels;

namespace LXP.Core.IServices
{
    public interface IUserReportServices
    {
        IEnumerable<UserReportViewModel> GetUserReport();
    }
}
