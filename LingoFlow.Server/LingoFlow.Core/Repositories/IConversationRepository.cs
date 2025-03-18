﻿using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Repositories
{
    public interface IConversationRepository
    {
        Task<IEnumerable<Conversation>> GetAllConversationsAsync();
        Task<Conversation?> GetConversationByIdAsync(int id);
        Task<Conversation> AddConversationAsync(Conversation conversation); // הוספת שיחה
        //Task<Conversation> StartConversationAsync(int userId, int subjectId);//התחלת הקלטה
    }
}
