using LXP.Common.ViewModels;
using LXP.Core.IServices;
using LXP.Data.IRepository;

namespace LXP.Core.Services
{
    public class UserReportServices : IUserReportServices
    {
        private readonly IUserReportRepository _userReportRepository;

        public UserReportServices(IUserReportRepository userReportRepository)
        {
            _userReportRepository = userReportRepository;
        }

        public IEnumerable<UserReportViewModel> GetUserReport()
        {
            return _userReportRepository.GetUserReport();
        }
    }
}
