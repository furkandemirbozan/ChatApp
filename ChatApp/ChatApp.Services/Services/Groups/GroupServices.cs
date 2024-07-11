using ChatApp.Data.Models;
using ChatApp.Data.Repositories.GroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatApp.Services.Services.Groups
{
    public class GroupServices : IGroupSerivces
    {
        private readonly IGroupRepository _groupRepository;

        public GroupServices(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<Data.Entities.Group> AddAsync(Data.Entities.Group entity)
        {
            return await _groupRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync()
        {
            return await _groupRepository.CountAsync();
        }

        public async Task<Data.Entities.Group> DeleteAsync(Data.Entities.Group entity)
        {
            return await _groupRepository.DeleteAsync(entity);
        }

        public async Task<Data.Entities.Group> GetByIdAsync(int id)
        {
            return await _groupRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Data.Entities.Group>> ListAllAsync(PaginationModel paginationModel)
        {
            return await _groupRepository.ListAllAsync(paginationModel);  
        }

        public async Task<Data.Entities.Group> UpdateAsync(Data.Entities.Group entity)
        {
            return await _groupRepository.UpdateAsync(entity);
        }
    }
}
