using LingoFlow.Core.Models;
using LingoFlow.Core.Repositories;
using LingoFlow.Core.Services;
using LingoFlow.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Service
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;

        public ConversationService(IConversationRepository conversationRepository, IUserRepository userRepository, ISubjectRepository subjectRepository)
        {
            _conversationRepository = conversationRepository;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<IEnumerable<Conversation>> GetAllConversationsAsync()
        {
            return await _conversationRepository.GetAllConversationsAsync();
        }

        public async Task<Conversation?> GetConversationByIdAsync(int id)
        {
            return await _conversationRepository.GetConversationByIdAsync(id);
        }
        public async Task<Conversation> AddConversationAsync(Conversation conversation)
        {
            if (conversation == null)
            {
                throw new ArgumentNullException(nameof(conversation)); // בדיקה שהמשתמש לא null
            }

            // מבצע הוספה דרך המאגר
            return await _conversationRepository.AddConversationAsync(conversation);
        }
        public async Task<Conversation?> StartRecordingAsync(int userId, int subjectId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) 
                return null;

            var subject = await _subjectRepository.GetSubjectByIdAsync(subjectId);
            if (subject == null) return null;

            // יצירת שיחה חדשה
            var conversation = new Conversation { UserId = userId, SubjectId = subjectId, StartTime = DateTime.UtcNow, Status = "Recording" };

            // שמירה במסד הנתונים דרך הרפוזיטורי
            return await _conversationRepository.AddConversationAsync(conversation);
        }
    }
}
