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
        public ActionResult Index()
        {
            var recipe = db.Recipe.Include(r => r.Image).Include(r => r.Ingredient).Include(r => r.Instruction).Include(r => r.Meal).Include(r => r.Video);
            return View(recipe.ToList());
        }

        // GET: Recipes/Search
        public ActionResult Search(string search)
        {
            var recipe = db.Recipe.Include(r => r.Image).Include(r => r.Ingredient).Include(r => r.Instruction).Include(r => r.Meal).Include(r => r.Video);
            return Json(recipe, JsonRequestBehavior.AllowGet);
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
            List<Ingredient> ingredient = new List<Ingredient>();
            Instruction instruction = new Instruction();
            Meal meal = new Meal();
            Image image = new Image();
            Video video = new Video();
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,ServingSize,LengthToMake,Rating,isFavorite,ingredient,instruction,meal,image,video")] Recipe recipe, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null && ImageUpload.ContentLength > 0)
                {
                    string path = Server.MapPath("~/Content/Pictures/RecipePictures/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    ImageUpload.SaveAs(path + Path.GetFileName(ImageUpload.FileName));
                    ViewBag.Message = "File uploaded successfully";
                }
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
