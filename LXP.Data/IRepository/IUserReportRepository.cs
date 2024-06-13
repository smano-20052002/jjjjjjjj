using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LXP.Common.ViewModels;

namespace LXP.Data.IRepository
{
    public interface IUserReportRepository
    {
        IEnumerable<UserReportViewModel> GetUserReport();
    }
}
