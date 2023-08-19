using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interface
{
    public interface IDepartmentService
    {
        Task AddNewDepartment(int managerID, string departmentName);
        Task<List<DepartmentModel>> GetDepartmentsByManager(int managerId);
    }
}
