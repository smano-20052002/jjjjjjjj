using LXP.Common.ViewModels.QuizEngineViewModel;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizEngineController : ControllerBase
    {
        private readonly IQuizEngineService _quizEngineService;

        public QuizEngineController(IQuizEngineService quizEngineService)
        {
            _quizEngineService = quizEngineService;
        }

        [HttpGet("quiz/{quizId}")]
        public async Task<IActionResult> GetQuizDetails(Guid quizId)
        {
            var quizDetails = await _quizEngineService.GetQuizByIdAsync(quizId);
            if (quizDetails == null)
            {
                return NotFound($"Quiz with ID {quizId} not found.");
            }
            return Ok(quizDetails);
        }

        [HttpGet("topic/{topicId}/quiz")]
        public async Task<IActionResult> GetQuizDetailsByTopicId(Guid topicId)
        {
            var quizDetails = await _quizEngineService.GetQuizDetailsByTopicIdAsync(topicId);
            if (quizDetails == null)
            {
                return NotFound($"No quiz found for topic with ID {topicId}.");
            }
            return Ok(quizDetails);
        }

        [HttpGet("quiz/{quizId}/questions")]
        public async Task<IActionResult> GetQuizQuestions(Guid quizId)
        {
            var questions = await _quizEngineService.GetQuestionsForQuizAsync(quizId);
            return Ok(questions);
        }

        [HttpPost("attempt")]
        public async Task<IActionResult> StartQuizAttempt(Guid learnerId, Guid quizId)
        {
            var attemptId = await _quizEngineService.StartQuizAttemptAsync(learnerId, quizId);
            return Ok(attemptId);
        }

        [HttpPost("answer")]
        public async Task<IActionResult> SubmitAnswer(AnswerSubmissionModel answerSubmissionModel)
        {
            await _quizEngineService.SubmitAnswerAsync(answerSubmissionModel);
            return Ok();
        }

        /// <summary>
        /// Api  Endpoint in development stage not ready to use yet
        /// </summary>

        [HttpPost("SubmitAnswerBatch")]
        public async Task<IActionResult> SubmitAnswerBatch(
            [FromBody] AnswerSubmissionBatchModel model
        )
        {
            try
            {
                await _quizEngineService.SubmitAnswerBatchAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Api  Endpoint in development stage not ready to use yet
        /// </summary>
        [HttpPost("attempt/cache-answers")]
        public async Task<IActionResult> CacheAnswers([FromBody] CachedAnswerSubmissionModel model)
        {
            try
            {
                await _quizEngineService.CacheAnswersAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Api  Endpoint in development stage not ready to use yet
        /// </summary>

        [HttpPost("attempt/submit-cached-answers")]
        public async Task<IActionResult> SubmitCachedAnswers(Guid learnerAttemptId)
        {
            try
            {
                await _quizEngineService.SubmitCachedAnswersAsync(learnerAttemptId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("attempts/{attemptId}")]
        public async Task<IActionResult> GetLearnerQuizAttempt(Guid attemptId)
        {
            var viewModel = await _quizEngineService.GetLearnerQuizAttemptAsync(attemptId);
            return Ok(viewModel);
        }

        [HttpPost("attempt/submit")]
        public async Task<IActionResult> SubmitQuizAttempt(Guid attemptId)
        {
            await _quizEngineService.SubmitQuizAttemptAsync(attemptId);
            return Ok();
        }

        [HttpGet("attempts/{attemptId}/result")]
        public async Task<IActionResult> GetLearnerQuizAttemptResult(Guid attemptId)
        {
            var viewModel = await _quizEngineService.GetLearnerQuizAttemptResultAsync(attemptId);
            return Ok(viewModel);
        }

        [HttpPost("retake")]
        public async Task<IActionResult> RetakeQuiz(Guid learnerId, Guid quizId)
        {
            var attemptId = await _quizEngineService.RetakeQuizAsync(learnerId, quizId);
            return Ok(attemptId);
        }
    }
}
