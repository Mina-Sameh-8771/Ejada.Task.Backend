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
    [Authorize(Roles = UserRoles.Manager)]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost("AddNewEmployee")]
        public async Task<IActionResult> AddNewEmployee(AddNewEmployeeDto requet)
        {
            var userModel = _mapper.Map<EmployeeModel>(requet);
            await _employeeService.AddNewEmployee(userModel);

            return Ok();
        }

        [HttpGet("GetEmployeeByDepartment")]
        public async Task<IActionResult> GetEmployeeByDepartment(int departmentID)
        {
            var employees = await _employeeService.GetEmployeeByDepartment(departmentID);

            return Ok(employees);
        }

        [HttpPost("RemoveEmployeeFromDepartment")]
        public async Task<IActionResult> RemoveEmployeeFromDepartment(RemoveEmployeeFromDepartmentDto request)
        {
            await _employeeService.RemoveEmployeeFromDepartment(request.employeeID , request.departmentID);
            return Ok();
        }

        [HttpGet("GetEmployeeByManager")]
        public async Task<IActionResult> GetEmployeeByManager(int managerId)
        {
            var employees = await _employeeService.GetEmployeeByManager(managerId);
            return Ok(employees);
        }
    }
}
