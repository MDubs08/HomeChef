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
    public class RecipeReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecipeReviews
        public ActionResult Index()
        {
            var recipeReview = db.RecipeReview.Include(r => r.Review);
            return View(recipeReview.ToList());
        }

        // GET: RecipeReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeReview recipeReview = db.RecipeReview.Find(id);
            if (recipeReview == null)
            {
                return HttpNotFound();
            }
            return View(recipeReview);
        }

        // GET: RecipeReviews/Create
        public ActionResult Create()
        {
            Review review = new Review();
            return View();
        }

        // POST: RecipeReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AverageRating,review")] RecipeReview recipeReview)
        {
            if (ModelState.IsValid)
            {
                db.RecipeReview.Add(recipeReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewID = new SelectList(db.Review, "ID", "Comment", recipeReview.ReviewID);
            return View(recipeReview);
        }

        // GET: RecipeReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeReview recipeReview = db.RecipeReview.Find(id);
            if (recipeReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewID = new SelectList(db.Review, "ID", "Comment", recipeReview.ReviewID);
            return View(recipeReview);
        }

        // POST: RecipeReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AverageRating,ReviewID")] RecipeReview recipeReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewID = new SelectList(db.Review, "ID", "Comment", recipeReview.ReviewID);
            return View(recipeReview);
        }

        // GET: RecipeReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeReview recipeReview = db.RecipeReview.Find(id);
            if (recipeReview == null)
            {
                return HttpNotFound();
            }
            return View(recipeReview);
        }

        // POST: RecipeReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeReview recipeReview = db.RecipeReview.Find(id);
            db.RecipeReview.Remove(recipeReview);
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
