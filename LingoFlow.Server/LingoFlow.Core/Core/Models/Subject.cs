namespace LingoFlow.Server.Core.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Word> Words { get; set; } = new();
    }
}
