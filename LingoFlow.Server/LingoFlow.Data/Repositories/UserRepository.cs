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
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);  // מחפש את המשתמש לפי מזהה
        }
        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();  // שמירה למסד נתונים

            return user;
        }
        public async Task UpdateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            // חיפוש המשתמש במסד נתונים
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            // עדכון פרטי המשתמש, אם קיימת ערך חדש
            existingUser.Email = user.Email ?? existingUser.Email;
            existingUser.Name = user.Name ?? existingUser.Name;

            // אם יש סיסמה חדשה, עדכון הסיסמה עם BCrypt
            if (!string.IsNullOrEmpty(user.Password))
            {
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            // שמירת השינויים במסד נתונים
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
        }


        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
