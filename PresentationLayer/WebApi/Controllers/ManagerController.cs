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
    [Authorize(Roles = UserRoles.Admin)]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public ManagerController(IManagerService managerService, IDepartmentService departmentService, IMapper mapper)
        {
            _managerService = managerService;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpPost("AddNewManager")]
        public async Task<IActionResult> AddNewManager(AddNewManagerDto requet)
        {
            var userModel = _mapper.Map<UserModel>(requet);
            await _managerService.AddNewManager(userModel);

            return Ok();
        }

        [HttpGet("GetManagers")]
        public async Task<IActionResult> GetManagers()
        {
            var managers = await _managerService.GetManagers();

            return Ok(managers);
        }
    }
}
