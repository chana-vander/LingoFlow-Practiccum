//using LingoFlow.Api.Models; // ודא שאתה מייבא את המודל של ה-DTO
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
        Task<IEnumerable<Word>> GetAllWordsAsync(); // מקבל רק את המודל Word
        Task<Word?> GetWordByIdAsync(int id);
        Task AddWordAsync(Word word); // הוספת פונקציה להוספה של מילה חדשה
        Task UpdateWordAsync(Word word); // עדכון מילה
        Task DeleteWordAsync(Word word); // מחיקת מילה
    }
}
