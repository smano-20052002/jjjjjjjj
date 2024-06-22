using LXP.Core.IServices;
using LXP.Data.IRepository;

namespace LXP.Core.Services
{
    public class LearnerAttemptServices : ILearnerAttemptServices
    {
        private readonly ILearnerAttemptRepository _repository;

        public LearnerAttemptServices(ILearnerAttemptRepository repository)
        {
            _repository = repository;
        }

        public object GetScoreByTopicIdAndLernerId(string LearnerId)
        {
            return _repository.GetScoreByTopicIdAndLernerId(Guid.Parse(LearnerId));
        }

        public object GetScoreByLearnerId(string LearnerId)
        {
            return _repository.GetScoreByLearnerId(Guid.Parse(LearnerId));
        }
    }
}
