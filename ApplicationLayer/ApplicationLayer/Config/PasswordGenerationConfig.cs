using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Config
{
    public class PasswordGenerationConfig
    {
        public bool UseDefualtPasswordAndDontSendMail { get; set; }
        public string DefualtPassword { get; set; }

    }
}
