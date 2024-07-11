using ChatApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Repositories.UserRepositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        public Task<User>GetByUserNameandPasswordAsync(string userName,string password);
    }
}
