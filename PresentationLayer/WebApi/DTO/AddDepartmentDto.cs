using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class AddDepartmentDto
    {
        public string Name { get; set; }
        public int ManagerID { get; set; }
    }
}
