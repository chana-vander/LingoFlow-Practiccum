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

        public ConversationService(IConversationRepository conversationRepository)
        {
            _conversationRepository= conversationRepository;
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
    }
}
