using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();  // תיקון החתימה
        Task<User?> GetUserByIdAsync(int id); // הוספנו גם פונקציה לחיפוש משתמש בודד
        Task<User> AddUserAsync(User user); // הוספת משתמש
        //IUserService GetAllUsersAsync();
        //Task<IEnumerable<User>> ToListAsync();
    }
}
