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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentEmployeeRepository _departmentEmployeeRepository;
        private readonly ISecurityService _securityService;

        public EmployeeService(IUserRepository userRepository, IDepartmentEmployeeRepository departmentEmployeeRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _departmentEmployeeRepository = departmentEmployeeRepository;
            _securityService = securityService;
        }

        public async Task AddNewEmployee(EmployeeModel userModel)
        {
            var employee = new DataAccessLayer.Entities.User
            {
                Birthday = userModel.Birthday,
                Email = userModel.Email,
                Name = userModel.Name,
                Password = _securityService.GeneratePassword(userModel.Email),
                PhoneNumber = userModel.PhoneNumber,
                RoleID = 3,
                Username = userModel.Username
            };
            await _userRepository.Add(employee);
            await _departmentEmployeeRepository.Add(employee.ID, userModel.DepartmentId);
        }

        public async Task<List<UserModel>> GetEmployeeByDepartment(int departmentID)
        {
            var employee = await _departmentEmployeeRepository.GetEmployeeByDepartment(departmentID);
            return employee.Select(s => new UserModel { 
                Birthday = s.Birthday,
                Email = s.Email,
                Name = s.Name,
                ID = s.ID,
                PhoneNumber = s.PhoneNumber,
                Username = s.Username
            }).ToList();
        }

        public async Task RemoveEmployeeFromDepartment(int employeeId , int departmentID)
        {
            await _departmentEmployeeRepository.Delete(employeeId, departmentID);
        }

        public async Task<List<EmployeeModel>> GetEmployeeByManager(int managerID)
        {
            var employees = await _departmentEmployeeRepository.GetEmployeeByManager(managerID);
            return employees.Select(s => new EmployeeModel {
                Birthday = s.Employee.Birthday,
                DepartmentId = s.DepartmentID,
                Email = s.Employee.Email,
                Name = s.Employee.Name,
                PhoneNumber = s.Employee.PhoneNumber,
                Username = s.Employee.Username,
                ID = s.Employee.ID
            }).ToList();
        }
    }
}
