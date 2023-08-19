using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Enum
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Employee = "Employee";

        public static string GetRole(int index)
        {
            string role = "";
            switch (index)
            {
                case 1:
                    role = Admin;
                    break;
                case 2:
                    role = Manager;
                    break;
                case 3:
                    role = Employee;
                    break;
            }
            return role;
        }
    }
}
