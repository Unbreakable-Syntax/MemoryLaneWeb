namespace MemoryUserService
{
    public interface IChatMessageService
    {
        Task<bool> CheckChatMessage(int id);
        Task AddChatMessage(ChatMessages message);
        Task<bool> DeleteChatMessage(int id);
    }
}
