﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNothing.Models;
using Microsoft.AspNetCore.Identity;

namespace Backend6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //Email Password уже есть

        public Int32 Rating { get; set; }
        public String Status { get; set; }

        public UserType UserType { get; set; }
        public Int32 UserTypeId { get; set; }

        public Geo Geo { get; set; }
        public Int32 GeoId { get; set; }

        public ICollection<Card> Cards { get; set; }

        //many to many
        public ICollection<TaskType> TaskTypes { get; set; }

    }
}
