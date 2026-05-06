namespace MemoryLaneWeb
{
    public interface IChatMessageService
    {
        Task<ChatMessages?> CheckChatMessage(int id);
        Task<ChatMessages?> CheckChatMessage(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime? sentat, bool? isread, bool? isbroadcast, int? patientid);
        Task<List<ChatMessages>> CheckChatMessages(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime? sentat, bool? isread, bool? isbroadcast, int? patientid, string orderby, bool isdesc, int limit, int offset);
        Task AddChatMessage(ChatMessages message);
        Task<bool> DeleteChatMessage(int id);
        Task MarkAsRead(int senderid, int recipientid);
    }
}
