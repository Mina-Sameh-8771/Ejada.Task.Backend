using ApplicationLayer.Enum;
using ApplicationLayer.Interface;
using ApplicationLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }


        [Authorize(Roles = UserRoles.Manager)]
        [HttpPost("AddNewTask")]
        public async Task<IActionResult> AddNewTask(AddNewTaskDto requet)
        {
            var userModel = _mapper.Map<TaskModel>(requet);
            await _taskService.CreateTask(userModel);

            return Ok();
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpDelete("RemoveTask")]
        public async Task<IActionResult> RemoveTask(int taskId)
        {
            await _taskService.RemoveTask(taskId);

            return Ok();
        }

        [Authorize(Roles = UserRoles.Employee)]
        [HttpGet("ComplateTask")]
        public async Task<IActionResult> ComplateTask(int taskId)
        {
            await _taskService.ComplateTask(taskId);

            return Ok();
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpGet("GetTasksByManager")]
        public async Task<IActionResult> GetTasksByManager(int managerId)
        {
           var tasks = await _taskService.GetTasksByManager(managerId);

            return Ok(tasks);
        }

        [Authorize(Roles = UserRoles.Employee)]
        [HttpGet("GetTasksByEmployee")]
        public async Task<IActionResult> GetTasksByEmployee(int employeeId)
        {
            var tasks = await _taskService.GetTasksByEmployee(employeeId);

            return Ok(tasks);
        }
    }
}
