using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class UserType
    {
        public Int32 Id { get; set; }
        public String Type { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
