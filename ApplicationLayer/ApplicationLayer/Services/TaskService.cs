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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task CreateTask(TaskModel taskModel)
        {
            await _taskRepository.Add(new DataAccessLayer.Entities.AssignedTask { 
                Description = taskModel.Description,
                EmployeeID = taskModel.EmployeeID,
                Name = taskModel.Name,
                TaskStatusID = 1
            });
        }

        public async Task RemoveTask(int taskId)
        {
            await _taskRepository.Delete(taskId);
        }

        public async Task ComplateTask(int taskId)
        {
            await _taskRepository.ComplateTask(taskId);
        }

        public async Task<List<TaskModel>> GetTasksByManager(int managerId)
        {
            var tasks = await _taskRepository.GetTasksByManager(managerId);

            return tasks.Select(s => new TaskModel { 
                Description = s.Description,
                 EmployeeID = s.EmployeeID,
                 Name = s.Name,
                 SubmissionDate = s.SubmissionDate,
                 ID = s.ID,
                 StatusId = s.TaskStatusID
            }).ToList();
        }

        public async Task<List<TaskModel>> GetTasksByEmployee(int employeeId)
        {
            var tasks = await _taskRepository.GetTasksByEmployee(employeeId);

            return tasks.Select(s => new TaskModel
            {
                Description = s.Description,
                EmployeeID = s.EmployeeID,
                Name = s.Name,
                SubmissionDate = s.SubmissionDate,
                ID = s.ID,
                StatusId = s.TaskStatusID
            }).ToList();
        }
    }
}
