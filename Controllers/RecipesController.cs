using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeChef.Models;
using System.IO;

namespace HomeChef.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipes
        public ActionResult Index(string search)
        {
            var recipes = from m in db.Recipe
                          select m;

            if (!String.IsNullOrEmpty(search))
            {
                recipes = recipes.Where(s => s.Name.Contains(search) || s.Description.Contains(search) || s.RecipeIngredient.Ingredient.Name.Contains(search) || s.Meal.MealTime.ToString().Contains(search) || s.Meal.MealType.ToString().Contains(search));
            }
            var recipe = db.Recipe.Include(r => r.Image).Include(r => r.RecipeIngredient).Include(r => r.Instruction).Include(r => r.Meal).Include(r => r.Video);
            return View(recipes);
        }

        // GET: Recipes/Search
        public ActionResult Search(string search)
        {
            var recipes = from m in db.Recipe
                          select m;

            if(!String.IsNullOrEmpty(search))
            {
                recipes = recipes.Where(s => s.Name.Contains(search) || s.Description.Contains(search) || s.RecipeIngredient.Ingredient.Name.Contains(search) || s.Meal.MealTime.ToString().Contains(search) || s.Meal.MealType.ToString().Contains(search));
            }
            return Json(recipes, JsonRequestBehavior.AllowGet);
        }

        // GET: Recipes/Category
        public ActionResult Category(string category)
        {
            var categories = from m in db.Recipe
                           select m;

            if(!String.IsNullOrEmpty(category))
            {
                categories = categories.Where(s => s.Meal.MealTime.ToString().Contains(category) || s.Meal.MealType.ToString().Contains(category));
            }
            var recipe = db.Recipe.Include(r => r.Image).Include(r => r.RecipeIngredient).Include(r => r.Instruction).Include(r => r.Meal).Include(r => r.Video).Where(x => x.Meal.MealTime.Equals(category) || x.Meal.MealType.Equals(category));
            return View(categories);
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Include(r => r.Instruction).Include(r => r.Instruction.Step).Include(r => r.RecipeIngredient).Include(r => r.RecipeIngredient.Ingredient).Include(r => r.Image).Include(r => r.Meal).Include(r => r.Video).Where(x => x.ID == id).SingleOrDefault();
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        [Authorize]
        public ActionResult Create()
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            Instruction instruction = new Instruction();
            Meal meal = new Meal();
            Image image = new Image();
            Video video = new Video();
            return View();
        }

        public ActionResult ImageUpload(HttpPostedFileBase ImageUpload)
        {
            if (ImageUpload.ContentLength > 0)
            {
                int MaxContentLength = 1024 * 1024 * 3;
                string[] AllowedFileExtensions = new string[] { ".jpg", ".png", ".jpeg", "pdf" };
                if (!AllowedFileExtensions.Contains(ImageUpload.FileName.Substring(ImageUpload.FileName.LastIndexOf('.'))))
                {
                    ModelState.AddModelError("Image", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                }
                else if (ImageUpload.ContentLength > MaxContentLength)
                {
                    ModelState.AddModelError("ImageUpload", "Your fild is too large, maximum allowed size is: " + MaxContentLength + " MB");
                }
                else
                {
                    var imageName = Path.GetFileName(ImageUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Pictures/RecipePictures"), imageName);
                    ImageUpload.SaveAs(path);
                    ModelState.Clear();
                    ViewBag.Message = "File uploaded successfully";
                }

            }
            return View();
        }

        public ActionResult AddIngredient()
        {
            RecipeIngredient RecipeIngredient = new RecipeIngredient();
            return View(RecipeIngredient);
        }

        public ActionResult AddStep()
        {
            Step Step = new Step();
            return View(Step);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,ServingSize,LengthToMake,Rating,isFavorite,recipeIngredient,instruction,meal,image,video")] Recipe recipe, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                db.Recipe.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImageID = new SelectList(db.Image, "ID", "Name", recipe.ImageID);
            ViewBag.RecipeIngredientID = new SelectList(db.RecipeIngredient, "ID", "Name", recipe.RecipeIngredientID);
            ViewBag.InstructionID = new SelectList(db.Instruction, "ID", "Name", recipe.InstructionID);
            ViewBag.MealID = new SelectList(db.Meal, "ID", "MealTime", recipe.MealID);
            ViewBag.VideoID = new SelectList(db.Video, "ID", "Name", recipe.VideoID);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        [Authorize]
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
            ViewBag.RecipeIngredientID = new SelectList(db.RecipeIngredient, "ID", "Name", recipe.RecipeIngredientID);
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
            ViewBag.RecipeIngredientID = new SelectList(db.RecipeIngredient, "ID", "Name", recipe.RecipeIngredientID);
            ViewBag.InstructionID = new SelectList(db.Instruction, "ID", "Name", recipe.InstructionID);
            ViewBag.MealID = new SelectList(db.Meal, "ID", "MealTime", recipe.MealID);
            ViewBag.VideoID = new SelectList(db.Video, "ID", "Name", recipe.VideoID);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        [Authorize]
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
