
using LingoFlow.Core.Models;
using LingoFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Data.Repositories
{
    public class WordRepository:IWordRepository
    {
        private readonly DataContext _context;

        public WordRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Word>> GetAllWordsAsync()
        {
            return await _context.Words.ToListAsync();
        }
        public async Task<Word?> GetWordByIdAsync(int id)
        {
            return await _context.Words.FirstOrDefaultAsync(c => c.Id == id);  // מחפש את המילה לפי מזהה
        }
    }
}
