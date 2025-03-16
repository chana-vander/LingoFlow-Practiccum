using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Repositories
{
    public interface IWordRepository
    {
        Task<IEnumerable<Word>> GetAllWordsAsync();
        Task<Word?> GetWordByIdAsync(int id);
    }
}
