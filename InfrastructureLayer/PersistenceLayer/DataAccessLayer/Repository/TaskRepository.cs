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
    public class TaskRepository : ITaskRepository
    {
        private readonly EmployeeContext _context;

        public TaskRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<List<AssignedTask>> GetTasksByEmployee(int employeeID)
        {
            return await _context.Task.Where(w => w.EmployeeID == employeeID && w.TaskStatusID == 1 && w.IsDeleted == false).ToListAsync();
        }
        
        public async Task<List<AssignedTask>> GetTasksByManager(int managerID)
        {
            var tasks = from departmentEmployee in _context.EmployeeDepatment
                        join department in _context.Department on departmentEmployee.DepartmentID equals department.ID
                        join assignedTask in _context.Task on departmentEmployee.EmployeeID equals assignedTask.EmployeeID
                        where department.ManagerID == managerID && assignedTask.IsDeleted == false
                        select assignedTask;

            return await tasks.ToListAsync();
        }

        public async Task Add(AssignedTask task)
        {
            await _context.Task.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int taskID)
        {
            var task = await _context.Task.Where(w => w.ID == taskID).FirstOrDefaultAsync();
            if (task != null)
            {
                task.IsDeleted = true;
                _context.Task.Update(task);
                await _context.SaveChangesAsync();
            }

        }

        public async Task ComplateTask(int taskID)
        {
            var task = await _context.Task.Where(w => w.ID == taskID).FirstOrDefaultAsync();
            if (task != null)
            {
                task.TaskStatusID = 2;
                task.SubmissionDate = DateTime.Now;
                _context.Task.Update(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ReAssignTask(int taskID , int employeeID)
        {
            var task = await _context.Task.Where(w => w.ID == taskID).FirstOrDefaultAsync();
            if (task != null)
            {
                task.EmployeeID = employeeID;
                _context.Task.Update(task);
                await _context.SaveChangesAsync();
            }
        }


    }
}
