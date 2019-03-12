using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW2_ASP.Models
{
    public class UserToActive
    {

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsActivate { get; set; }
    }
}