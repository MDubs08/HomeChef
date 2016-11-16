using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class CartItem
    {
        [Key]

        public string ItemID { get; set; }
        public string CartID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("Ingredient")]
        public int IngredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}