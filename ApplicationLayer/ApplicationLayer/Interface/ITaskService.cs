using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interface
{
    public interface ITaskService
    {
        Task CreateTask(TaskModel taskModel);
        Task RemoveTask(int taskId);
        Task<List<TaskModel>> GetTasksByManager(int managerId);
        Task ComplateTask(int taskId);
        Task<List<TaskModel>> GetTasksByEmployee(int employeeId);
    }
}
