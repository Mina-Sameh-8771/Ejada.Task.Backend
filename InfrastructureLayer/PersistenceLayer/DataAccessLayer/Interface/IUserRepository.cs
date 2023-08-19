using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserame(string Username);
        Task<bool> IsUsernameExist(string Username);
        Task Add(User user);
        Task<List<User>> GetManagers();
    }
}
