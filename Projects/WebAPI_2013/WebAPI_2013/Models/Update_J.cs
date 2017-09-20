using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_2013.Models
{
    public class Update_J
    {
        [Required]
        [MaxLength(140)]
        public string Status { get; set; }
        //public DateTime Date { get; set; }
        public DateTime Date { get; set; }
    }
}