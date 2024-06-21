using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

