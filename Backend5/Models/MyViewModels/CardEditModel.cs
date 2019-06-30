using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend5.Models.MyViewModels
{
    public class CardEditModel
    {
        [Required] public String Code { get; set; }
        [Required] public String Date { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String CVV { get; set; }
    }
}
