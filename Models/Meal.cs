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
    public class HolidayMeal
    {
        public string Christmas = "Christmas";
        public string CincoDeMayo = "Cinco De Mayo";
        public string Easter = "Easter";
        public string FathersDay = "Father's Day";
        public string Halloween = "Halloween";
        public string Hanukkah = "Hanukkah";
        public string IndependenceDay = "Independence Day";
        public string MothersDay = "Mother's Day";
        public string NewYears = "New Year's";
        public string StPatricksDay = "St. Patrick's Day";
        public string Thanksgiving = "Thanksgiving";
        public string ValentinesDay = "Valentine's Day";
    }
}