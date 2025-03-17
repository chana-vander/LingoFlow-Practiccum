using LingoFlow.Core.Models;
using LingoFlow.Core.Repositories;
using LingoFlow.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Service
{
    public class UserService : IUserService
    {
        //private readonly IUserRepository _userRepository;

        //public UserService(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        //public async Task<IEnumerable<User>> GetAllUsersAsync()
        //{
        //    return await _userRepository.GetAllUsersAsync();
        //}

        //public async Task<User?> GetUserByIdAsync(int id)
        //{
        //    return await _userRepository.GetUserByIdAsync(id);
        //}
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task<User?> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user)); // בדיקה שהמשתמש לא null
            }

            // בדיקה אם המייל כבר קיים
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return null; // מחזירים null אם המשתמש כבר קיים
            }

            // הוספת משתמש
            return await _userRepository.AddUserAsync(user);
        }
        // פונקציה ליצירת טוקן JWT למשתמש
        public string GenerateJwtToken(User user)
        {
            // מייצרים את המפתח להצפנה על בסיס המידע שנמצא בקובץ הקונפיגורציה
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            // יצירת אובייקט שמטפל בטוקנים של JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            // יצירת אובייקט TokenDescriptor שמכיל את פרטי הטוקן
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // מגדירים את המידע (Claims) שנכנס לטוקן:
                Subject = new ClaimsIdentity(new[]
                {
            // מזהה המשתמש (ID)
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            // כתובת הדוא"ל של המשתמש
            new Claim(ClaimTypes.Email, user.Email)
        }),

                // זמן פקיעת הטוקן, אשר נלקח מהקונפיגורציה או ברירת מחדל של 2 שעות
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:ExpireHours"] ?? "2")),

                // הגדרת שיטת ההצפנה ליצירת החותמת של הטוקן
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // יצירת הטוקן על ידי החדרת הנתונים מה-TokenDescriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // מחזירים את הטוקן כשרשור (string) כך שניתן להשתמש בו
            return tokenHandler.WriteToken(token);
        }

        // פונקציה להתחברות של משתמש ומילוי טוקן JWT אם ההתחברות הצליחה
        public async Task<string?> LoginUserAsync(User model)
        {
            //if (model == null)
            //    throw new ArgumentNullException(nameof(model), "User model cannot be null");

            //var user = await _userRepository.GetUserByEmailAsync(model.Email);

            //if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            //    throw new UnauthorizedAccessException("Invalid email or password.");

            //return GenerateJwtToken(user);\
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password.");

            // אם הסיסמה לא תואמת, בודקים אם salt ישן ויש לעדכן אותה
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                // אפשר להוסיף כאן לוגיקה לעדכון הסיסמה ל-BCrypt עם salt חדש
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                await _userRepository.UpdateUserAsync(user); // עדכון הסיסמה במסד הנתונים
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            return GenerateJwtToken(user);
        }

    }
}
