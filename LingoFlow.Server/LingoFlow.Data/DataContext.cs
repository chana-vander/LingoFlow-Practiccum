using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Data
{
    internal class DataContext
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
