using DataAccessLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int ManagerID { get; set; }
        public virtual User Manager { get; set; }
    }
}
