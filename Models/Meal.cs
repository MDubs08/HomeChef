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
        Appetizer,
        Dessert,
        Drink,
        [Display(Name = "Main Course")]
        MainCourse,
        Salad,
        [Display(Name = "Side Dish")]
        SideDish,
        Snack,
        Soup
    }
    public enum HolidayMeal
    {
        Christmas,
        [Display(Name = "Cinco De Mayo")]
        CincoDeMayo,
        Easter,
        [Display(Name = "Father's Day")]
        FathersDay,
        Halloween,
        Hanukkah,
        [Display(Name = "Independence Day")]
        IndependenceDay,
        [Display(Name = "Mother's Day")]
        MothersDay,
        [Display(Name = "New Year's Day")]
        NewYears,
        [Display(Name = "St. Patrick's Day")]
        StPatricksDay,
        Thanksgiving,
        [Display(Name = "Valentine's Day")]
        ValentinesDay
    }
}