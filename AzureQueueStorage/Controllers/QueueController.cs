using AzureQueueStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureQueueStorage.Controllers
{
    [Route("api/queue")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] string messageText, string queueName)
        {
            await _queueService.SendMessageAsync(queueName, messageText);
            return Ok("Message sent");
        }

        [HttpGet("receive")]
        public async Task<IActionResult> ReceiveMessage(string queueName)
        {
            string message = await _queueService.ReceiveMessageAsync(queueName);

            if (message != null)
            {
                return Ok(message);
            }

            return NotFound("No messages found");
        }

    }
}
