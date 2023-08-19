using ApplicationLayer.Interface;
using ApplicationLayer.Models;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public ManagerService(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public async Task AddNewManager(UserModel userModel)
        {
            await _userRepository.Add(new DataAccessLayer.Entities.User {
                Birthday = userModel.Birthday,
                Email = userModel.Email,
                Name = userModel.Name,
                Password = _securityService.GeneratePassword(userModel.Email),
                PhoneNumber = userModel.PhoneNumber,
                RoleID = 2,
                Username = userModel.Username
            });
        }

        public async Task<List<ManagerModel>> GetManagers()
        {
            var managers = await _userRepository.GetManagers();
            return managers.Select(s => new ManagerModel
            { 
                ID = s.ID,
                Name = s.Name
            }).ToList();
        }
    }
}
