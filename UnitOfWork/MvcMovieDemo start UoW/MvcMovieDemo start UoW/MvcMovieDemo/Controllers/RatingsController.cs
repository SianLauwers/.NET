using System.Linq;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using MvcMovieDemo.Data;
using MvcMovieDemo.Models;
using MvcMovieDemo.DAL;
using System.Data;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        private IUnitOfWork _uow;

        public RatingsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Ratings/List
        public IActionResult List()
        {

            return View(_uow.RatingRepository.GetAll());
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

            try
            {
                if (ModelState.IsValid)
                {
                    _uow.RatingRepository.Insert(rating);
                    _uow.Save();
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");

            }     

            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_uow.RatingRepository.GetByID(id));
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RatingID,Code,Name")] Rating rating)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _uow.RatingRepository.Update(rating);
                    _uow.Save();
                    return RedirectToAction("List");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                _uow.RatingRepository.Delete(id);
                _uow.Save();
                return RedirectToAction("List");
            }
            catch (DataException)
            {
                throw;
            }

        }
    }
}

