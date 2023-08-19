using DataAccessLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class EmployeeDepatment : BaseEntity
    {
        public int EmployeeID { get; set; }
        public virtual User Employee { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}
