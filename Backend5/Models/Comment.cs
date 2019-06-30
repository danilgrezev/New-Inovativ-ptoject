using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend5.Models
{
    public class Comment
    {
        public Int32 Id { get; set; }
        public String Text { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser Sender { get; set; }
        public String SenderId { get; set; }

        public ApplicationUser Recipient { get; set; }
        public String RecipientId { get; set; }


      
    }
}
