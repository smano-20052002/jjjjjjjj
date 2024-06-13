using System.Text.Json;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelToJsonController : BaseController
    {
        private readonly IExcelToJsonService _excelToJsonService;

        public ExcelToJsonController(IExcelToJsonService excelToJsonService)
        {
            _excelToJsonService = excelToJsonService;
        }

        [HttpPost("ConvertExcelToJson")]
        [ProducesResponseType(typeof(FileContentResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        [ProducesResponseType(typeof(ObjectResult), 500)]
        public async Task<IActionResult> ConvertExcelToJson(IFormFile file, Guid quizId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(
                    CreateFailureResponse("The file is required and cannot be empty.", 400)
                );
            }

            if (quizId == Guid.Empty)
            {
                return BadRequest(CreateFailureResponse("The quiz ID must be a valid GUID.", 400));
            }

            try
            {
                var jsonData = await _excelToJsonService.ConvertExcelToJsonAsync(file);
                var validatedJsonData = _excelToJsonService.ValidateQuizData(jsonData);
                await _excelToJsonService.SaveQuizDataAsync(validatedJsonData, quizId);

                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                var jsonString = JsonSerializer.Serialize(validatedJsonData, options);
                var byteArray = System.Text.Encoding.UTF8.GetBytes(jsonString);
                var stream = new MemoryStream(byteArray);

                return File(stream, "application/json", "convertedData.json");
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    CreateFailureResponse(
                        $"An error occurred while converting Excel to JSON: {ex.Message}",
                        500
                    )
                );
            }
        }
    }
}
