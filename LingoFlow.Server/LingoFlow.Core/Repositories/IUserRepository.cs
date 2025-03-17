using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);

        Task<User> AddUserAsync(User user); // הוספת משתמש
        Task UpdateUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
