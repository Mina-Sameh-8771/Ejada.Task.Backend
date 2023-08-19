using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class RemoveEmployeeFromDepartmentDto
    {
        public int departmentID { get; set; }
        public int employeeID { get; set; }
    }
}
