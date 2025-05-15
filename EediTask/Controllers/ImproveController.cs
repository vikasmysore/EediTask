using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EediTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImproveController : ControllerBase
    {
        private readonly IImproveService _service;

        public ImproveController(IImproveService service)
        {
            _service = service;
        }

        [HttpGet("{studentId}/subtopics")]
        public async Task<ActionResult<IEnumerable<SubTopic>>> GetSubTopics(int studentId)
        {
            var result = await _service.GetSubTopicsWithIncorrectAnswersAsync(studentId);
            return Ok(result);
        }

        [HttpGet("{studentId}/subtopics/{subTopicId}/questions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(int studentId, int subTopicId)
        {
            var result = await _service.GetIncorrectQuestionsForSubTopicAsync(studentId, subTopicId);
            return Ok(result);
        }

        [HttpPost("answer/{answerId}")]
        public async Task<IActionResult> UpdateAnswer(int answerId, [FromBody] string newAnswer)
        {
            await _service.UpdateAnswerAsync(answerId, newAnswer);
            return NoContent();
        }
    }
}
