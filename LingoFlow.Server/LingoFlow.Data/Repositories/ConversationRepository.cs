using LingoFlow.Core.Models;
using LingoFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Data.Repositories
{
    public class ConversationRepository:IConversationRepository
    {
        private readonly DataContext _context;

        public ConversationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Conversation>> GetAllConversationsAsync()
        {
            return await _context.Conversations.ToListAsync();
        }
        public async Task<Conversation?> GetConversationByIdAsync(int id)
        {
            return await _context.Conversations.FirstOrDefaultAsync(c => c.Id == id);  // מחפש את המשתמש לפי מזהה
        }
        public async Task<Conversation> AddConversationAsync(Conversation conversation)
        {
            if (conversation == null)
            {
                throw new ArgumentNullException(nameof(conversation));
            }

            _context.Conversations.Add(conversation); // מוסיף את המשתמש למסד הנתונים
            await _context.SaveChangesAsync(); // שומר את השינויים

            return conversation;
        }
        //public async Task<Conversation> StartConversationAsync(int userId, int subjectId)
        //{
        //    // בדוק אם המשתמש קיים
        //    var user = await _userRepository.GetUserByIdAsync(userId);
        //    if (user == null) return null;

        //    // בדוק אם הנושא קיים
        //    var subject = await _subjectRepository.GetSubjectByIdAsync(subjectId);
        //    if (subject == null) return null;

        //    // יצירת שיחה חדשה
        //    var conversation = new Conversation
        //    {
        //        UserId = userId,
        //        SubjectId = subjectId,
        //        StartTime = DateTime.UtcNow,
        //        Status = "Recording"
        //    };

        //    // שמירה במסד הנתונים
        //    _context.Conversations.Add(conversation);
        //    await _context.SaveChangesAsync();

        //    return conversation;
        //}
    }
}
