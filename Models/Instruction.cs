using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Instruction
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Instructions")]
        public string Name { get; set; }
        [Display(Name = "Steps")]
        public List<string> Steps = new List<string>();
        [Display(Name = "Prep Time")]
        public int PrepTime { get; set; }
    }
}