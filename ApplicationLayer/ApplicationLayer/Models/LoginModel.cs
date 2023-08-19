using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class LoginModel
    {
        public bool IsLogin { get; set; }
        public string jwtToken { get; set; }
    }
}
