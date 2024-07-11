using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly ChatAppDbContext _context;
        public UserRepository(IGenericRepository<User> genericRepository, ChatAppDbContext context)
        {
            _genericRepository = genericRepository;
            _context = context;
        }
        public async Task<User> AddAsync(User entity)
        {
            return await _genericRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync()
        {
            return await _genericRepository.CountAsync();
        }

        public async Task<User> DeleteAsync(User entity)
        {
            return await _genericRepository.DeleteAsync(entity);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByUserNameandPasswordAsync(string userName, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.UserName==userName&&x.Password==password);
        }

        public async Task<IReadOnlyList<User>> ListAllAsync(PaginationModel paginationModel)
        {
            return await _genericRepository.ListAllAsync(paginationModel);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _genericRepository.UpdateAsync(entity);
        }
    }
}
