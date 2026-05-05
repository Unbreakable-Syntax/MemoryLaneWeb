namespace MemoryLaneWeb
{
    public interface IChatMessageService
    {
        Task<ChatMessages?> CheckChatMessage(int id);
        Task<ChatMessages?> CheckChatMessage(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime? sentat, bool? isread);
        Task<List<ChatMessages>> CheckChatMessages(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime? sentat, bool? isread);
        Task AddChatMessage(ChatMessages message);
        Task<bool> DeleteChatMessage(int id);
    }
}
