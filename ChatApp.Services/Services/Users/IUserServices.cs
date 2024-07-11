using ChatApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Services.Services.Users
{
    public interface IUserServices:IGenericService<User>
    {
        public Task<User> GetByUserNameAndPasswordAsync(string userName, string password);
    }
}
