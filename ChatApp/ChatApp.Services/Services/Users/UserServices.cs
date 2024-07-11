using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Data.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Services.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddAsync(User entity)
        {
            return await _userRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync()
        {
            return await _userRepository.CountAsync();
        }

        public async Task<User> DeleteAsync(User entity)
        {
            return await _userRepository.DeleteAsync(entity);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await  _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            return await _userRepository.GetByUserNameandPasswordAsync(userName, password);
        }

        public async Task<IReadOnlyList<User>> ListAllAsync(PaginationModel paginationModel)
        {
            return await _userRepository.ListAllAsync(paginationModel);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}
