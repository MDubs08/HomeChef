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
        [Display(Name = "Meal Time Frame")]
        public MealTime MealTime { get; set; }
        [Display(Name = "Meal Type")]
        public MealType MealType { get; set; }
        [Display(Name = "Holiday Meal")]
        public bool isHoliday { get; set; }
        [Display(Name = "Holiday Name")]
        public HolidayMeal HolidayMeal { get; set; }
    }
    public enum MealTime
    {
        Breakfast,
        Brunch,
        Lunch,
        Dinner
    }
    public enum MealType
    {
        [Display(Name = "Appetizer")]
        Appetizer,
        [Display(Name = "Dessert")]
        Dessert,
        [Display(Name = "Drink")]
        Drink,
        [Display(Name = "Main Course")]
        MainCourse,
        [Display(Name = "Salad")]
        Salad,
        [Display(Name = "Side Dish")]
        SideDish,
        [Display(Name = "Snack")]
        Snack,
        [Display(Name = "Soup")]
        Soup
    }
    public enum HolidayMeal
    {
        [Display(Name = "Christmas")]
        Christmas,
        [Display(Name = "Cinco De Mayo")]
        CincoDeMayo,
        [Display(Name = "Easter")]
        Easter,
        [Display(Name = "Father's Day")]
        FathersDay,
        [Display(Name = "Halloween")]
        Halloween,
        [Display(Name = "Hanukkah")]
        Hanukkah,
        [Display(Name = "Independence Day")]
        IndependenceDay,
        [Display(Name = "Mother's Day")]
        MothersDay,
        [Display(Name = "New Year's Day")]
        NewYears,
        [Display(Name = "St. Patrick's Day")]
        StPatricksDay,
        [Display(Name = "Thanksgiving")]
        Thanksgiving,
        [Display(Name = "Valentine's Day")]
        ValentinesDay
    }
}