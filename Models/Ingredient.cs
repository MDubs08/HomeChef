using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(StringEnumConverter))]
        public Measurement Measurement { get; set; }
    }
    public enum Measurement
    {
        [JsonConverter(typeof(StringEnumConverter))]
        Centimeter,
        [Display(Name = "Cup")]
        Cup,
        [Display(Name = "Fluid Ounce")]
        FluidOunce,
        [Display(Name = "Foot")]
        Foot,
        [Display(Name = "Gallon")]
        Gallon,
        [Display(Name = "Gram")]
        Gram,
        [Display(Name = "Inch")]
        Inch,
        [Display(Name = "Kilogram")]
        Kilogram,
        [Display(Name = "Liter")]
        Liter,
        [Display(Name = "Meter")]
        Meter,
        [Display(Name = "Milliliter")]
        Milliliter,
        [Display(Name = "Ounce")]
        Ounce,
        [Display(Name = "Pint")]
        Pint,
        [JsonConverter(typeof(StringEnumConverter))]
        Pound,
        [Display(Name = "Quart")]
        Quart,
        [Display(Name = "Tablespoon")]
        Tablespoon,
        [Display(Name = "Teaspoon")]
        Teaspoon
    }
}
