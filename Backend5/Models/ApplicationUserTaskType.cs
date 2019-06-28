using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Backend5.Models
{
    public class ApplicationUserTaskType
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Int32 ApplicationUserId { get; set; }

        public TaskType TaskType { get; set; }
        public Int32 TaskTypeId { get; set; }

    }
}
