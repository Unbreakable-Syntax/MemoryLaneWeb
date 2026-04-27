using Microsoft.AspNetCore.Mvc;

namespace MemoryLaneWeb
{
    [ApiController]
    [Route("api/chatmessages")]
    public class ChatMessagesController : ControllerBase
    {
        private readonly IChatMessageService _service;
        public ChatMessagesController(IChatMessageService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckChatMessage(id);
            if (!result) return NotFound();
            return Ok("Chat message exists");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ChatMessages message)
        {
            await _service.AddChatMessage(message);
            return Ok("Chat message added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteChatMessage(id);
            if (!result) return NotFound();
            return Ok("Chat message deleted");
        }
    }
}
