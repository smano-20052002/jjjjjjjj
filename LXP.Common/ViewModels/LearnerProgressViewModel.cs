using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LXP.Common.Entities;

namespace LXP.Common.ViewModels
{
    public class LearnerProgressViewModel
    {
        public Guid CourseId { get; set; }

        public Guid TopicId { get; set; }

        public Guid MaterialId { get; set; }

        public Guid LearnerId { get; set; }

        public TimeOnly WatchTime { get; set; }

        //public TimeOnly TotalTime { get; set; }
    }
}
