﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Image
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Image Name")]
        public string Name { get; set; }
        [Display(Name = "Image")]
        public byte [] ImageFile { get; set; }
    }
}