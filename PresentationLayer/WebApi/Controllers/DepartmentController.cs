using ApplicationLayer.Enum;
using ApplicationLayer.Interface;
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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment(AddDepartmentDto request)
        {
            await _departmentService.AddNewDepartment(request.ManagerID , request.Name);
            return Ok();
        }

        [Authorize(Roles = UserRoles.Manager)]
        [HttpGet("GetDepartmentsByManager")]
        public async Task<IActionResult> GetDepartmentsByManager(int managerId)
        {
            var departments = await _departmentService.GetDepartmentsByManager(managerId);
            return Ok(departments);
        }
    }
}
