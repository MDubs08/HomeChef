using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Prep Time")]
        public int PrepTime { get; set; }

        [ForeignKey("Step")]
        public int StepID { get; set; }
        public Step Step { get; set; }
    }
}