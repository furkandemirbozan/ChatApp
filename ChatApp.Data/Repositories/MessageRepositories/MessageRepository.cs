using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IGenericRepository<Message> _genereicRepository;
        public MessageRepository(IGenericRepository<Message> genereicRepository)
        {
            _genereicRepository = genereicRepository;
        }
        public async Task<Message> AddAsync(Message entity)
        {
            return await _genereicRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync()
        {
            return await _genereicRepository.CountAsync();
        }

        public async Task<Message> DeleteAsync(Message entity)
        {
            return await _genereicRepository.DeleteAsync(entity);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _genereicRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Message>> ListAllAsync(PaginationModel paginationModel)
        {
            return await _genereicRepository.ListAllAsync(paginationModel);
        }

        public async Task<Message> UpdateAsync(Message entity)
        {
            return await _genereicRepository.UpdateAsync(entity);
        }
    }
}
