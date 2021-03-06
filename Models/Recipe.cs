﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeChef.Models
{
    public class Recipe
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }
        [Display(Name = "Recipe Description")]
        public string Description { get; set; }
        [Display(Name = "Serving Size")]
        public int ServingSize { get; set; }
        [Display(Name = "Time to Create Recipe")]
        public int LengthToMake { get; set; }
        [Display(Name = "Favorite Recipe")]
        public bool isFavorite { get; set; }

        [ForeignKey("RecipeIngredient")]
        public int RecipeIngredientID { get; set; }
        public RecipeIngredient RecipeIngredient { get; set; }

        [ForeignKey("Instruction")]
        public int InstructionID { get; set; }
        public Instruction Instruction { get; set; }

        [ForeignKey("Image")]
        public int ImageID { get; set; }
        public Image Image { get; set; }

        [ForeignKey("Video")]
        public int VideoID { get; set; }
        public Video Video { get; set; }

        [ForeignKey("Meal")]
        public int MealID { get; set; }
        public Meal Meal { get; set; }
    }
}