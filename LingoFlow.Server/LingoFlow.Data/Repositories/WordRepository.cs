
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

        // הוספת מילה חדשה
        public async Task AddWordAsync(Word word)
        {
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
        }

        // עדכון מילה קיימת
        public async Task UpdateWordAsync(Word word)
        {
            _context.Words.Update(word);
            await _context.SaveChangesAsync();
        }

        // מחיקת מילה
        public async Task DeleteWordAsync(Word word)
        {
            _context.Words.Remove(word);
            await _context.SaveChangesAsync();
        }
    }
}
