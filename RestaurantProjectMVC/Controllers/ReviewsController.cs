using System.Linq;
using System.Net;
using System.Web.Mvc;
using RestaurantProjectMVC.Models;
using RestaurantProjectMVC.Data;
using NLog;

namespace RestaurantProjectMVC.Controllers
{
    public class ReviewsController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ReviewRepository rr = new ReviewRepository(new RestaurantDbContext());
        // GET: Reviews
        public ActionResult Index()
        {
            logger.Trace("Reviews Loaded");
            var resviews = rr.GetAll();
            return View(resviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = rr.GetId(id.GetValueOrDefault());
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            var result = rr.GetRestuarants();
            var result2 = rr.GetAll();
            ViewBag.RestarantId = new SelectList(result, "RestaurantId", "Name");
            ViewBag.profileURL = new SelectList(result2, "profileURL", "profileURL");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,ReviewMessage,Rating,profileURL,RestarantId")] Review review)
        {
            if (ModelState.IsValid)
            {
                rr.Insert(review);
                logger.Trace("Review Created");
                return RedirectToAction("Index");
            }
            var result = rr.GetRestuarants();
            var result2 = rr.GetAll();
            ViewBag.profileURL = new SelectList(result2, "profileURL", "profileURL");
            ViewBag.RestarantId = new SelectList(result, "RestaurantId", "Name", review.RestarantId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = rr.GetId(id.GetValueOrDefault());
            if (review == null)
            {
                return HttpNotFound();
            }
            var result = rr.GetRestuarants();
            var result2 = rr.GetAll();
            ViewBag.profileURL = new SelectList(result2, "profileURL", "profileURL");
            ViewBag.RestarantId = new SelectList(result, "RestaurantId", "Name", review.RestarantId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,ReviewMessage,Rating,profileURL,RestarantId")] Review review)
        {
            if (ModelState.IsValid)
            {
                rr.Update(review);
                logger.Trace("Reviews Edited");
                return RedirectToAction("Index");
            }
            var result2 = rr.GetAll();
            ViewBag.profileURL = new SelectList(result2, "profileURL", "profileURL");
            var result = rr.GetRestuarants().ToList();
            ViewBag.RestarantId = new SelectList(result, "RestaurantId", "Name", review.RestarantId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = rr.GetId(id.GetValueOrDefault());
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rr.Delete(id);
            logger.Trace("Review Deleted");
            return RedirectToAction("Index");
        }
        
    }
}
