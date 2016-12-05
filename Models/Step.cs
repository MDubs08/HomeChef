using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Step
    {
        [Key]

        public int ID { get; set; }
        public string Steps { get; set; }
    }
}