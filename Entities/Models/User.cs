using Entites.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entites
{
    public class User: Validation
    {
        public User()
        {
            Phones = new List<Telephone>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Created_At { get; set; }
        public string Last_Login { get; set; }
        public List<Telephone> Phones { get; set; }

    }
}
