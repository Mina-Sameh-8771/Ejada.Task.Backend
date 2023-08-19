using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interface
{
    public interface IManagerService
    {
        Task AddNewManager(UserModel userModel);
        Task<List<ManagerModel>> GetManagers();
    }
}
