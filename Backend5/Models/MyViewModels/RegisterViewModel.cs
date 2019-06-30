using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models.MyViewModels
{
    public class RegisterViewModel
    {
        public String Name { get; set; }
        public String Email { get; set; }

        public String Type { get; set; }
        public String Password { get; set; }
    }
}
