using LingoFlow.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Data.Repositories
{
    public class ManagerRepository
    {

        DataContext _dataContext;

        public IUserRepository UserM { get; }
        public IConversationRepository ConversationM { get; }
        public IFeedbackRepository FeedbackM { get; }
        public ISubjectRepository SubjectM { get; }
        public IWordRepository WordM { get; }

        public ManagerRepository(DataContext dataContext, IUserRepository userM, IConversationRepository conversationM, IFeedbackRepository feedbackM, ISubjectRepository subjectM, IWordRepository wordM)
        {
            _dataContext = dataContext;
            UserM = userM;
            ConversationM = conversationM;
            FeedbackM = feedbackM;
            SubjectM = subjectM;
            WordM = wordM;
        }

        public async Task saveAsync()
        {
            _dataContext.SaveChanges();
        }

    }
}
