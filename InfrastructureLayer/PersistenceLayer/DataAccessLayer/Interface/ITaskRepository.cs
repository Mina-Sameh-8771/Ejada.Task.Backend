using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ITaskRepository
    {
        Task<List<AssignedTask>> GetTasksByEmployee(int employeeID);
        Task<List<AssignedTask>> GetTasksByManager(int managerID);
        Task Add(AssignedTask task);
        Task Delete(int taskID);
        Task ComplateTask(int taskID);
        Task ReAssignTask(int taskID, int employeeID);
    }
}
