using LingoFlow.Core.Models;
using LingoFlow.Core.Repositories;
using LingoFlow.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Service
{
    public class WordService:IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<IEnumerable<Word>> GetAllWordsAsync()
        {
            return await _wordRepository.GetAllWordsAsync();
        }

        public async Task<Word?> GetWordByIdAsync(int id)
        {
            return await _wordRepository.GetWordByIdAsync(id);
        }
    }
}
