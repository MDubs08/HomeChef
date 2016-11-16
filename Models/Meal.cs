using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Meal
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Meal Time Frame ex. Dinner")]
        public string MealTime { get; set; }
        [Display(Name = "Meal Type ex. Desert")]
        public string MealType { get; set; }
        [Display(Name = "Holiday Meal")]
        public bool isHoliday { get; set; }
        [Display(Name = "Holiday Name")]
        public string HolidayMeal { get; set; }
    }
}