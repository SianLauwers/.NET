using Microsoft.EntityFrameworkCore;
using MvcMovieDemo.Data;
using MvcMovieDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovieDemo.DAL
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var rating = _context.Ratings.Find(id);
            _context.Ratings.Remove(rating);
        }

        public IEnumerable<Movie> GetAll()
        {
            // ToList -> IEnumberable
            return _context.Movies.ToList();
        }

        public Movie GetByID(int id)
        {
            var movie = _context.Movies.Include(m => m.Rating).SingleOrDefault(m => m.MovieID == id);
            return _context.Movies.Find(id);
        }

        public void Insert(Movie obj)
        {
            _context.Movies.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Movie obj)
        {
            _context.Movies.Update(obj);
        }
    }
}
