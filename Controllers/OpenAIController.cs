using Microsoft.AspNetCore.Mvc;

namespace openai_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Ask([FromQuery] string question)
        {
            var api = new OpenAI_API.OpenAIAPI("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");
            var result = await api.Completions.GetCompletion(question);
            return Ok(result);
        }
    }
}
