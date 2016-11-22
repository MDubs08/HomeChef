using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeChef.Models;

namespace HomeChef.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipes
        public ActionResult Index()
        {
            var recipe = db.Recipe.Include(r => r.Image).Include(r => r.Ingredient).Include(r => r.Instruction).Include(r => r.Meal).Include(r => r.Video);
            return View(recipe.ToList());
        }

        public IEnumerable<Recipe> Recipes()
        {
            List<Recipe> recipe = new List<Recipe>();
            return recipe;
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.ImageID = new SelectList(db.Image, "ID", "Name");
            ViewBag.IngredientID = new SelectList(db.Ingredient, "ID", "Name");
            ViewBag.InstructionID = new SelectList(db.Instruction, "ID", "Name");
            ViewBag.MealID = new SelectList(db.Meal, "ID", "MealTime");
            ViewBag.VideoID = new SelectList(db.Video, "ID", "Name");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,ServingSize,LengthToMake,Rating,isFavorite,IngredientID,InstructionID,ImageID,VideoID,MealID")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipe.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImageID = new SelectList(db.Image, "ID", "Name", recipe.ImageID);
            ViewBag.IngredientID = new SelectList(db.Ingredient, "ID", "Name", recipe.IngredientID);
            ViewBag.InstructionID = new SelectList(db.Instruction, "ID", "Name", recipe.InstructionID);
            ViewBag.MealID = new SelectList(db.Meal, "ID", "MealTime", recipe.MealID);
            ViewBag.VideoID = new SelectList(db.Video, "ID", "Name", recipe.VideoID);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageID = new SelectList(db.Image, "ID", "Name", recipe.ImageID);
            ViewBag.IngredientID = new SelectList(db.Ingredient, "ID", "Name", recipe.IngredientID);
            ViewBag.InstructionID = new SelectList(db.Instruction, "ID", "Name", recipe.InstructionID);
            ViewBag.MealID = new SelectList(db.Meal, "ID", "MealTime", recipe.MealID);
            ViewBag.VideoID = new SelectList(db.Video, "ID", "Name", recipe.VideoID);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,ServingSize,LengthToMake,Rating,isFavorite,IngredientID,InstructionID,ImageID,VideoID,MealID")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImageID = new SelectList(db.Image, "ID", "Name", recipe.ImageID);
            ViewBag.IngredientID = new SelectList(db.Ingredient, "ID", "Name", recipe.IngredientID);
            ViewBag.InstructionID = new SelectList(db.Instruction, "ID", "Name", recipe.InstructionID);
            ViewBag.MealID = new SelectList(db.Meal, "ID", "MealTime", recipe.MealID);
            ViewBag.VideoID = new SelectList(db.Video, "ID", "Name", recipe.VideoID);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipe.Find(id);
            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
