namespace LingoFlow.Server.Core.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string AudioFilePath { get; set; }
        public DateTime RecordedAt { get; set; }
        public Feedback Feedback { get; set; }
    }
}
