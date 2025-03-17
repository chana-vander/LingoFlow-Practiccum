using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LingoFlow.Api.Models;
namespace LingoFlow.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();  // תיקון החתימה
        Task<User?> GetUserByIdAsync(int id); // הוספנו גם פונקציה לחיפוש משתמש בודד
        Task<User?> AddUserAsync(User user); // הוספת משתמש
        Task<string> LoginUserAsync(User req); // פונקציה זו מחזירה טוקן JWT
        //Task UpdateUserAsync(User req);
        string GenerateJwtToken(User user);
    }
}
