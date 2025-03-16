using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Services
{
    public interface IWordService
    {
        Task<IEnumerable<Word>> GetAllWordsAsync();
        Task<Word?> GetWordByIdAsync(int id);
    }
}
