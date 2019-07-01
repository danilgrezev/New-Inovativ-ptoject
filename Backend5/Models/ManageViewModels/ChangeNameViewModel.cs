using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models.ManageViewModels
{
    public class ChangeNameViewModel
    {
        [Required]
        [Display(Name = "Current name")]
        public string OldName { get; set; }

        [Required]
        [Display(Name = "New name")]
        public string NewName { get; set; }

        
        [Display(Name = "Confirm new name")]
        
        public string ConfirmName { get; set; }

    }
}
