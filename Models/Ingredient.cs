using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Ingredient
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Ingredient")]
        public string Name { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Measurement")]
        public List<string> Measurement { get; set; }
    }
}