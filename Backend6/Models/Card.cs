using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoNothing.Models
{
    public class Card
    {
        public Int32 Id { get; set; }
        [Required] public String Code { get; set; }
        [Required] public String Date { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String CVV { get; set; }
    }
}
