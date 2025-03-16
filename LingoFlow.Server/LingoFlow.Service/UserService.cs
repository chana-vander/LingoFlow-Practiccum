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
    public class UserService:IUserService
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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user)); // בדיקה שהמשתמש לא null
            }

            // מבצע הוספה דרך המאגר
            return await _userRepository.AddUserAsync(user);
        }
    }
}
