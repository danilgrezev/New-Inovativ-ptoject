using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend6.Models;

namespace DoNothing.Models
{
    public class TaskType
    {
        public Int32 Id { get; set; }
        public String Type { get; set; }

        public ICollection<ApplicationUserTaskType> ApplicationUsers { get; set; }
    }
}
