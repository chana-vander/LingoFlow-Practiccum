using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Models
{
    internal class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Translation { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
