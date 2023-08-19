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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository userRepository)
        {
            _departmentRepository = userRepository;
        }

        public async Task AddNewDepartment(int managerID , string departmentName)
        {
            await _departmentRepository.Add(new DataAccessLayer.Entities.Department {
                ManagerID = managerID,
                Name = departmentName
            });
        }

        public async Task<List<DepartmentModel>> GetDepartmentsByManager(int managerId)
        {
            var departments = await _departmentRepository.GetDepartmentsByManager(managerId);

            return departments.Select(s => new DepartmentModel
            {
                ID = s.ID,
                Name = s.Name
            }).ToList();
        }
    }
}
