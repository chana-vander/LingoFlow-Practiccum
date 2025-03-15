namespace LingoFlow.Server.Core.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Translation { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
