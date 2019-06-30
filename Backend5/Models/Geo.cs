﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Geo
    {
        public Int32 Id { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String District { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public ICollection<MyTask> MyTasks { get; set; }
    }
}