using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Repositories
{
    public interface IMamagerRepository
    {

        IUserRepository UserM { get; }
        IConversationRepository ConversationM { get; }
        IFeedbackRepository FeedbackM { get; }
        ISubjectRepository SubjectM { get; }
        IWordRepository WordM { get; }

        Task SaveChangesAsync();

    }
}
