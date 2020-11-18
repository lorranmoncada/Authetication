using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Models
{
    public class Telephone
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int Number { get; set; }
        public int Area_Code { get; set; }
        public string Country_Code { get; set; }
    }
}
