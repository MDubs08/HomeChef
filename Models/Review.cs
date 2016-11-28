using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Review
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        [Display(Name = "Rating")]
        public int Rating { get; set; }
    }
}