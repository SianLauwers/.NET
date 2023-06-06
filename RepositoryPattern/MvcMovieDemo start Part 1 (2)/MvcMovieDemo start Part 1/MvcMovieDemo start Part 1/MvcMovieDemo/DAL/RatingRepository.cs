using MvcMovieDemo.Data;
using MvcMovieDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MvcMovieDemo.DAL
{
    public class RatingRepository : IRepository<Rating>
    {
        private MovieContext _context;

        public RatingRepository(MovieContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var rating = _context.Ratings.Find(id);
            _context.Ratings.Remove(rating);
        }

        public IEnumerable<Rating> GetAll()
        {
            // ToList -> IEnumberable
            return _context.Ratings.ToList();
        }

        public Rating GetByID(int id)
        {
            return _context.Ratings.Find(id);
        }

        public void Insert(Rating obj)
        {
            _context.Ratings.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Rating obj)
        {
            _context.Ratings.Update(obj);
        }
    }
}