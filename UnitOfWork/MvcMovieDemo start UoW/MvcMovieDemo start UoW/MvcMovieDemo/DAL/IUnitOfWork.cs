using MvcMovieDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovieDemo.DAL
{
    public interface IUnitOfWork
    {
        public GenericRepository<Movie> MovieRepository { get; }
        public GenericRepository<Rating> RatingRepository { get; }
        void Save();
    }
}
