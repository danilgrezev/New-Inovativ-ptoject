using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend6.Models;

namespace DoNothing.Models
{
    public class Card
    {
        public Int32 Id { get; set; }
        [Required] public String Code { get; set; }
        [Required] public String Date { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String CVV { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Int32 ApplicationUserId { get; set; }

    }
}
