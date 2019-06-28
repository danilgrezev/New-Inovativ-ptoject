using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoNothing.Models
{
    public class Insurance
    {
        public Int32 Id { get; set; }
        [Required] public String Code { get; set; }
        public Decimal Price { get; set; }
    }
}
