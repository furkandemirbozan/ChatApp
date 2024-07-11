using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Data.Repositories.MessageRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Services.Services.Messages
{
    public class MessageServices : IMessageServices
    {
        private readonly IMessageRepository _messageRepository;
        public MessageServices(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<Message> AddAsync(Message entity)
        {
            return await _messageRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync()
        {
            return await _messageRepository.CountAsync();
        }

        public async Task<Message> DeleteAsync(Message entity)
        {
            return await _messageRepository.DeleteAsync(entity);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Message>> ListAllAsync(PaginationModel paginationModel)
        {
            return await _messageRepository.ListAllAsync(paginationModel);
        }

        public async Task<Message> UpdateAsync(Message entity)
        {
            return await _messageRepository.UpdateAsync(entity);
        }
    }
}
