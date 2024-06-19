using LXP.Common.ViewModels.FeedbackResponseViewModel;
using LXP.Services;
using LXP.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LXP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackResponseDetailsController : ControllerBase
    {
        private readonly IFeedbackResponseDetailsService _feedbackResponseDetailsService;

        public FeedbackResponseDetailsController(
            IFeedbackResponseDetailsService feedbackResponseDetailsService
        )
        {
            _feedbackResponseDetailsService = feedbackResponseDetailsService;
        }

        [HttpGet("quiz/{quizId}")]
        public IActionResult GetQuizFeedbackResponses(Guid quizId)
        {
            var responses = _feedbackResponseDetailsService.GetQuizFeedbackResponses(quizId);
            return Ok(responses);
        }

        [HttpGet("topic/{topicId}")]
        public IActionResult GetTopicFeedbackResponses(Guid topicId)
        {
            var responses = _feedbackResponseDetailsService.GetTopicFeedbackResponses(topicId);
            return Ok(responses);
        }

        [HttpGet("quiz/{quizId}/learner/{learnerId}")]
        public IActionResult GetQuizFeedbackResponsesByLearner(Guid quizId, Guid learnerId)
        {
            var responses = _feedbackResponseDetailsService.GetQuizFeedbackResponsesByLearner(
                quizId,
                learnerId
            );
            return Ok(responses);
        }

        [HttpGet("topic/{topicId}/learner/{learnerId}")]
        public IActionResult GetTopicFeedbackResponsesByLearner(Guid topicId, Guid learnerId)
        {
            var responses = _feedbackResponseDetailsService.GetTopicFeedbackResponsesByLearner(
                topicId,
                learnerId
            );
            return Ok(responses);
        }
    }
}
