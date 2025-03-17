using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Dto
{
    public class ConversationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }
        //public string AudioFilePath { get; set; }
        public DateTime RecordedAt { get; set; }
        //public Feedback Feedback { get; set; }
    }
}
