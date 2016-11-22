using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Ingredient
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Ingredient")]
        public string Name { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Measurement")]
        public Measurement Measurement { get; set; }
    }
    public enum Measurement
    {
        Centimeter,
        Cup,
        FluidOunce,
        Foot,
        Gallon,
        Gram,
        Inch,
        Kilogram,
        Liter,
        Meter,
        Milliliter,
        Ounce,
        Pint,
        Pound,
        Quart,
        Tablespoon,
        Teaspoon
    }
}
