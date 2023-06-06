using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Data;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        private IRepository<Rating> _ratingRepository;
        //private readonly MovieContext _context;

        public RatingsController(MovieContext context)
        {
            _ratingRepository = new RatingRepository(context);
        }

        // GET: Ratings/List
        public IActionResult List()
        {
            //var ratings = _context.Ratings.OrderBy(r => r.Name);

            return View(_ratingRepository.GetAll());
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(rating);
                _context.SaveChanges();*/
                _ratingRepository.Insert(rating);
                _ratingRepository.Save();
                return RedirectToAction("List");
            }
            return View(_ratingRepository);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int id)
        {
            /*var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);*/

            return View(_ratingRepository.GetByID(id));
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        /* _context.Update(rating);
                        _context.SaveChanges();*/
                        _ratingRepository.Update(rating);
                        _ratingRepository.Save();
                        return RedirectToAction("List");
                    }
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int id)
        {
            /*var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            _context.Ratings.Remove(rating);
            _context.SaveChanges();*/
            _ratingRepository.Delete(id);
            _ratingRepository.Save();
            return RedirectToAction("List");
        }
    }
}
