using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class RecipeReview
    {
        [Key]

        public int ID { get; set; }
        public int? AverageRating { get; set; }

        [ForeignKey("Review")]
        public int ReviewID { get; set; }
        public Review Review { get; set; }
    }
}