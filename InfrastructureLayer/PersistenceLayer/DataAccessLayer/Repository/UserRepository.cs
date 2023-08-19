using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeContext _context;

        public UserRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUserame(string Username)
        {
            return await _context.User.Where(u => u.Username == Username && u.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<bool> IsUsernameExist(string Username)
        {
            return await _context.User.Where(u => u.Username == Username && u.IsDeleted == false).AnyAsync();
        }

        public async Task Add(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetManagers()
        {
            return await _context.User.Where(w => w.RoleID == 2 && w.IsDeleted == false).ToListAsync();
        }

        

    }
}
