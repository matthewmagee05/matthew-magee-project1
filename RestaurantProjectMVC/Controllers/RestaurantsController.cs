using System.Net;
using System.Web.Mvc;
using RestaurantProjectMVC.Models;
using RestaurantProjectMVC.Data;
using NLog;

namespace RestaurantProjectMVC.Controllers
{
    public class RestaurantsController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private RestaurantRepository rr = new RestaurantRepository(new RestaurantDbContext());

        // GET: Restaurants
        public ActionResult Index(string searchString, string searchCriteria)
        {
            logger.Trace("Restuarants Loaded");
            return View(rr.SearchAll(searchString, searchCriteria));  
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var restaurant = rr.GetId(id.GetValueOrDefault());
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantId,Name,Address,ZipCode,PhoneNumber,Description,RestaruantImageURL")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                rr.Insert(restaurant);
                return RedirectToAction("Index");
            }
            logger.Trace("New Restaurant Added");
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var restaurant = rr.GetId(id.GetValueOrDefault());
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId,Name,Address,ZipCode,PhoneNumber,Description,RestaruantImageURL")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                rr.Update(restaurant);
                logger.Trace("Restuarant " + restaurant.Name + " Edited");
                return RedirectToAction("Index");
            }
            
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var restaurant = rr.GetId(id.GetValueOrDefault());
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rr.Delete(id);
            logger.Trace("Restuarant Deleted");
            return RedirectToAction("Index");
        }
    }


}


