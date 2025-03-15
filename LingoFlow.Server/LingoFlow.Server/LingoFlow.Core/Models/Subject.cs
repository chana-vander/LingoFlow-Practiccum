using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Word> Words { get; set; } = new();
    }
}
