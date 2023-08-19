using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentEmployeeRepository
    {
        Task<IEnumerable<User>> GetEmployeeByDepartment(int departmentID);
        Task Add(int empolyeeID, int departmentID);
        Task Delete(int empolyeeID, int departmentID);
        Task<List<EmployeeDepatment>> GetEmployeeByManager(int managerID);
    }
}
