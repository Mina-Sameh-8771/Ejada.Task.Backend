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
    public class DepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public DepartmentEmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetEmployeeByDepartment(int departmentID)
        {
            var employees = from departmentEmployee in _context.EmployeeDepatment
                            join user in _context.User on departmentEmployee.EmployeeID equals user.ID
                            where departmentEmployee.IsDeleted == false && departmentEmployee.DepartmentID == departmentID
                            select user;

            return await employees.ToListAsync();
        }

        public async Task Add(int empolyeeID , int departmentID)
        {
            await _context.EmployeeDepatment.AddAsync(new Entities.EmployeeDepatment { 
                DepartmentID = departmentID,
                EmployeeID = empolyeeID
            });
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int empolyeeID, int departmentID)
        {
            var departmentEmployee = await _context.EmployeeDepatment.Where(w => w.EmployeeID == empolyeeID && w.DepartmentID == departmentID).FirstOrDefaultAsync();
            if(departmentEmployee != null)
            {
                departmentEmployee.IsDeleted = true;
                _context.EmployeeDepatment.Update(departmentEmployee);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<EmployeeDepatment>> GetEmployeeByManager(int managerID)
        {
            return await _context.EmployeeDepatment.Where(w => w.Department.ManagerID == managerID && w.IsDeleted == false)
                .Include(c => c.Employee).ToListAsync();
        }

    }
}
