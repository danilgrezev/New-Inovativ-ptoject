using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models.MyViewModels
{
    public class ClientCreateTaskModel
    {
        public String Header { get; set; }
        public String Text { get; set; }
        public Int32? Price { get; set; }

        public String TaskTypeId { get; set; }
    }
}
