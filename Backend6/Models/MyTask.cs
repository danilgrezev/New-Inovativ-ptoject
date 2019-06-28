using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend6.Models;

namespace DoNothing.Models
{
    public class MyTask
    {
        public Int32 Id { get; set; }
        public String Header { get; set; }
        public String Text { get; set; }
        public String Status { get; set; }
        public Int32 Priority { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime ApplyingTime { get; set; }

        public Insurance Insurance { get; set; }
        public Int32 InsuranceId { get; set; }

        public TaskType TaskType { get; set; }
        public Int32 TaskTypeId { get; set; }

        public ApplicationUser Client { get; set; }
        public Int32 ClientId { get; set; }

        public ApplicationUser Employee { get; set; }
        public Int32 EmployeeId { get; set; }

        public Geo Geo { get; set; }
        public Int32 GeoId { get; set; }

    }
}
