using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovieDemo.Data;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovieDemo.Models.ViewModels;
using MvcMovieDemo.Models;
using MvcMovieDemo.DAL;

namespace MvcMovieDemo.Controllers
{
    public class MoviesController : Controller
    {
        private IRepository<Movie> _movieRepository;
        private RatingRepository _ratingRepository;
        //private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _movieRepository = new MovieRepository(context);
            _ratingRepository = new RatingRepository(context);
        }

        public IActionResult List(int ratingID = 0)
        {
            var listMoviesVM = new ListMoviesViewModel();


            if (ratingID != 0)
            {
                listMoviesVM.Movies = _movieRepository.GetAll().Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
            }
            else
            {
                listMoviesVM.Movies = _movieRepository.GetAll().OrderBy(m => m.Title).ToList();
            }

            listMoviesVM.Ratings = new SelectList(_ratingRepository.GetAll().OrderBy(r => r.Name),
                        "RatingID", "Name");
            listMoviesVM.ratingID = ratingID;

            return View(listMoviesVM);

        }


        public IActionResult Details(int id)
        {
            var movie = _movieRepository.GetByID(id);

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["Ratings"] =
                new SelectList(_ratingRepository.GetAll().OrderBy(r => r.Name),
                               "RatingID",
                               "Name");

            return View();
        }

        //POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MovieId,Title, Genre,ReleaseDate, RatingID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(movie);
                _context.SaveChanges();*/
                _movieRepository.Insert(movie);
                _movieRepository.Save();
                return RedirectToAction("List");
            }

            //when insert doesn't succeed:
            ViewData["Ratings"] =
            new SelectList(_ratingRepository.GetAll().OrderBy(r => r.Name),
                           "RatingID",
                           "Name");
            return View(movie);
        }

    }
}
