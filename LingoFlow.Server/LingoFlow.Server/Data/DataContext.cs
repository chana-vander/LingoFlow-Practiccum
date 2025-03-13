using LingoFlow.Server.Core.Models;

namespace LingoFlow.Server.Data
{
    public class DataContext
    {
        public List<User> users;
        public List<Conversation> conversations;
        public List<Feedback> feedbacks;
        public List<Subject> subjects;
        public List<Word> words;
        public DataContext()
        {

        }
    }
}
