using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class AddNewTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }

        public int EmployeeID { get; set; }
    }
}
