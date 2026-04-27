namespace MemoryLaneWeb
{
    public class PostgresChatMessages : IChatMessageService
    {
        private readonly AppDbContext _db;

        public PostgresChatMessages(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ChatMessages?> CheckChatMessage(int id)
        {
            var message = await _db.ChatMessages.FindAsync(id);
            if (message == null) return null;
            return message;
        }

        public async Task AddChatMessage(ChatMessages message)
        {
            _db.ChatMessages.Add(message);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteChatMessage(int id)
        {
            var message = await _db.ChatMessages.FindAsync(id);
            if (message == null) return false;
            _db.ChatMessages.Remove(message);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
