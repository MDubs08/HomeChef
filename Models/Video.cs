using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Video
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Video Name")]
        public string Name { get; set; }
        [Display(Name = "Video")]
        public byte [] VideoFile { get; set; }
    }
}