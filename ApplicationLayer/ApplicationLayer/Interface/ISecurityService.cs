using ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interface
{
    public interface ISecurityService
    {
        Task<LoginModel> Login(string Username, string Password);
        string GeneratePassword(string email);
    }
}
