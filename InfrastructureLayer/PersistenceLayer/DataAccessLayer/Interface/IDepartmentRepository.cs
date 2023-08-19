using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentRepository
    {
        Task Add(Department department);
        Task<List<Department>> GetDepartmentsByManager(int managerID);
    }
}
