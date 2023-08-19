using ApplicationLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;

namespace WebApi.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<AddNewManagerDto, UserModel>();
            CreateMap<AddNewEmployeeDto, EmployeeModel>();
            CreateMap<AddNewTaskDto, TaskModel>();
        }
    }
}
