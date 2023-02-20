using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace openai_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAIController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public OpenAIController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration.GetSection("OpenAIKey").Value;
        }

        [HttpGet]
        public async Task<IActionResult> Ask([FromQuery] string question)
        {
            var api = new OpenAI_API.OpenAIAPI(_apiKey);
            var request = new CompletionRequest(question, model: Model.DavinciText, 
                temperature: 0.6, max_tokens: 500);
            var result = await api.Completions.CreateCompletionAsync(request);
            return Ok(result.Completions.FirstOrDefault()?.Text);
        }

        //[Route("Image")]
        //[HttpGet]
        //public async Task<IActionResult> GetImage([FromQuery] string question)
        //{
        //    var api = new OpenAI_API.OpenAIAPI(_apiKey);
        //    var request = new CompletionRequest(question, model: Model.DavinciText,
        //        temperature: 0.6, max_tokens: 500);
        //    var result = await api.Completions.
        //}
    }
}
