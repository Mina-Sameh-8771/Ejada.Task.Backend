using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interface
{
    public interface IMailService
    {
        void SendEmail(string ToEmail, string Subject, string Body);
    }
}
