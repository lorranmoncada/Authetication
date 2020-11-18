using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class UserLogin : Validation
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
