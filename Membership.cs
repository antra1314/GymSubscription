using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StayFitGym.Model
{
    public class Membership
    {
        [Required]
        [Key]
        public string UserID { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Plan { get; set; }
        [Required]
        public string Payment { get; set; }      
        public string Summary { get; set; }

    }
}
