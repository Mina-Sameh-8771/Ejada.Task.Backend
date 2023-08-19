using DataAccessLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AssignedTask : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }

        public int EmployeeID { get; set; }
        public virtual User Employee { get; set; }
        
        public int TaskStatusID { get; set; }
        public virtual AssignedTaskStatus TaskStatus { get; set; }
    }
}
