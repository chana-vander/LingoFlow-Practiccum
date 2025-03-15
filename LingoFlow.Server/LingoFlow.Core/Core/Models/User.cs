using Microsoft.VisualBasic;

namespace LingoFlow.Server.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Conversation> Conversations { get; set; } = new();
    }
}
