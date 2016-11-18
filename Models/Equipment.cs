using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Equipment
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Equipment")]
        public string Name { get; set; }
        [Display(Name = "Temperature Type")]
        public List<string> Temperature { get; set; }
    }
}