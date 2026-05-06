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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.CheckChatMessage(id);
            if (result == null) return NotFound("Chat message not found");
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Get(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime sentat, bool? isread, bool? isbroadcast, int? patientid)
        {
            var result = await _service.CheckChatMessage(senderid, sendername, senderrole, recipientid, content, sentat, isread, isbroadcast, patientid);
            if (result == null) return NotFound("Chat message not found");
            return Ok(result);
        }

        [HttpGet("searchmultiple")]
        public async Task<IActionResult> GetAll(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime sentat, bool? isread, bool? isbroadcast, int? patientid, string orderby, bool isdesc, int limit, int offset)
        {
            var result = await _service.CheckChatMessages(senderid, sendername, senderrole, recipientid, content, sentat, isread, isbroadcast, patientid, orderby, isdesc, limit, offset);
            if (result.Count == 0) return NotFound("Chat message not found");
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ChatMessages message)
        {
            await _service.AddChatMessage(message);
            return Ok("Chat message added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteChatMessage(id);
            if (!result) return NotFound("Chat message not found");
            return Ok("Chat message deleted");
        }

        [HttpGet("markasread")]
        public async Task<IActionResult> MarkRead(int senderid, int recipientid)
        {
            await _service.MarkAsRead(senderid, recipientid);
            return Ok();
        }
    }
}
