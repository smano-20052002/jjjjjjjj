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

        /// <summary>
        /// Retrieves feedback responses for a specific quiz by its ID.
        /// </summary>
        /// <param name="quizId">The unique identifier of the quiz.</param>
        /// <response code="200">Success on finding the feedback responses. The response body contains the list of feedback responses for the quiz.</response>
        /// <response code="404">Not found if no feedback responses exist for the provided quiz ID.</response>
        [HttpGet("quiz/{quizId}")]
        public IActionResult GetQuizFeedbackResponses(Guid quizId)
        {
            var responses = _feedbackResponseDetailsService.GetQuizFeedbackResponses(quizId);
            return Ok(responses);
        }

        /// <summary>
        /// Retrieves feedback responses for a specific topic by its ID.
        /// </summary>
        /// <param name="topicId">The unique identifier of the topic.</param>
        /// <response code="200">Success on finding the feedback responses. The response body contains the list of feedback responses for the topic.</response>
        /// <response code="404">Not found if no feedback responses exist for the provided topic ID.</response>
        [HttpGet("topic/{topicId}")]
        public IActionResult GetTopicFeedbackResponses(Guid topicId)
        {
            var responses = _feedbackResponseDetailsService.GetTopicFeedbackResponses(topicId);
            return Ok(responses);
        }

        /// <summary>
        /// Retrieves feedback responses for a specific quiz and learner by their IDs.
        /// </summary>
        /// <param name="quizId">The unique identifier of the quiz.</param>
        /// <param name="learnerId">The unique identifier of the learner.</param>
        /// <response code="200">Success on finding the feedback responses. The response body contains the list of feedback responses for the quiz by the learner.</response>
        /// <response code="404">Not found if no feedback responses exist for the provided quiz ID and learner ID.</response>
        [HttpGet("quiz/{quizId}/learner/{learnerId}")]
        public IActionResult GetQuizFeedbackResponsesByLearner(Guid quizId, Guid learnerId)
        {
            var responses = _feedbackResponseDetailsService.GetQuizFeedbackResponsesByLearner(
                quizId,
                learnerId
            );
            return Ok(responses);
        }

        /// <summary>
        /// Retrieves feedback responses for a specific topic and learner by their IDs.
        /// </summary>
        /// <param name="topicId">The unique identifier of the topic.</param>
        /// <param name="learnerId">The unique identifier of the learner.</param>
        /// <response code="200">Success on finding the feedback responses. The response body contains the list of feedback responses for the topic by the learner.</response>
        /// <response code="404">Not found if no feedback responses exist for the provided topic ID and learner ID.</response>
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
