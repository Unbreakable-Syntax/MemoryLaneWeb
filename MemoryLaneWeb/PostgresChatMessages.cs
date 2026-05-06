using Microsoft.EntityFrameworkCore;

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

        public async Task<ChatMessages?> CheckChatMessage(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime? sentat, bool? isread, bool? isbroadcast, int? patientid)
        {
            var query = _db.ChatMessages.AsQueryable();
            if (senderid.HasValue) query = query.Where(u => u.SenderID == senderid.Value);
            if (!string.IsNullOrEmpty(sendername)) query = query.Where(u => sendername.Equals(u.SenderName));
            if (!string.IsNullOrEmpty(senderrole)) query = query.Where(u => senderrole.Equals(u.SenderRole));
            if (recipientid.HasValue) query = query.Where(u => u.RecipientID == recipientid.Value);
            if (!string.IsNullOrEmpty(content)) query = query.Where(u => content.Equals(u.Content));
            if (sentat.HasValue) query = query.Where(u => u.SentAt == sentat.Value);
            if (isread.HasValue) query = query.Where(u => u.IsRead == isread.Value);
            if (isbroadcast.HasValue) query = query.Where(u => u.IsBroadcast == isbroadcast.Value);
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            var chatmessage = await query.FirstOrDefaultAsync();
            return chatmessage;
        }

        public async Task<List<ChatMessages>> CheckChatMessages(int? senderid, string sendername, string senderrole, int? recipientid, string content, DateTime? sentat, bool? isread, bool? isbroadcast, int? patientid, string orderby, bool isdesc, int limit, int offset)
        {
            var query = _db.ChatMessages.AsQueryable();
            if (senderid.HasValue) query = query.Where(u => u.SenderID == senderid.Value);
            if (!string.IsNullOrEmpty(sendername)) query = query.Where(u => sendername.Equals(u.SenderName));
            if (!string.IsNullOrEmpty(senderrole)) query = query.Where(u => senderrole.Equals(u.SenderRole));
            if (recipientid.HasValue) query = query.Where(u => u.RecipientID == recipientid.Value);
            if (!string.IsNullOrEmpty(content)) query = query.Where(u => content.Equals(u.Content));
            if (sentat.HasValue) query = query.Where(u => u.SentAt == sentat.Value);
            if (isread.HasValue) query = query.Where(u => u.IsRead == isread.Value);
            if (isbroadcast.HasValue) query = query.Where(u => u.IsBroadcast == isbroadcast.Value);
            if (patientid.HasValue) query = query.Where(u => u.PatientID == patientid.Value);
            List<ChatMessages> chatmessages = new List<ChatMessages>();
            if (isdesc) await query.OrderByDescending(e => EF.Property<object>(e, orderby)).Skip(offset).Take(limit).ToListAsync();
            else await query.OrderBy(e => EF.Property<object>(e, orderby)).Skip(offset).Take(limit).ToListAsync();
            return chatmessages;
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

        public async Task MarkAsRead(int senderid, int recipientid)
        {
            var query = _db.ChatMessages.AsQueryable();
            query = query.Where(u => u.SenderID == senderid && u.RecipientID == recipientid && u.IsRead == false);
            var result = await query.ToListAsync();
            if (result.Count == 0) return;
            bool dbChanged = false;
            foreach(ChatMessages msg in result)
            {
                msg.IsRead = true;
                dbChanged = true;
            }
            if (dbChanged) await _db.SaveChangesAsync();
        }
    }
}
