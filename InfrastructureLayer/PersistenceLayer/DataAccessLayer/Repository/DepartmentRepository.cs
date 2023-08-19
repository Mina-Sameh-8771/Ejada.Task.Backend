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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _context;

        public DepartmentRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task Add(Department department)
        {
            await _context.Department.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Department>> GetDepartmentsByManager(int managerID)
        {
            return await _context.Department.Where(w => w.ManagerID == managerID).ToListAsync();
        }
    }
}
