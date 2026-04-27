namespace MemoryLaneWeb
{
    public interface IChatMessageService
    {
        Task<ChatMessages?> CheckChatMessage(int id);
        Task AddChatMessage(ChatMessages message);
        Task<bool> DeleteChatMessage(int id);
    }
}
