using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interface
{
    public interface IEmployeeService
    {
        Task AddNewEmployee(EmployeeModel userModel);
        Task<List<UserModel>> GetEmployeeByDepartment(int departmentID);
        Task RemoveEmployeeFromDepartment(int employeeId, int departmentID);
        Task<List<EmployeeModel>> GetEmployeeByManager(int managerID);
    }
}
