using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Services
{
    public interface IConversationService
    {
        Task<IEnumerable<Conversation>> GetAllConversationsAsync();  // תיקון החתימה
        Task<Conversation?> GetConversationByIdAsync(int id); // הוספנו גם פונקציה לחיפוש משתמש בודד
        Task<Conversation> AddConversationAsync(Conversation conversation); // הוספת שיחה
        //Task<bool> StartRecordingAsync(int userId, int subjectId);
        Task<Conversation?> StartRecordingAsync(int userId, int subjectId);
    }
}
