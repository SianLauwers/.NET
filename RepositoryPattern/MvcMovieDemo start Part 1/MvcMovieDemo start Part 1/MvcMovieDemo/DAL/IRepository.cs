using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovieDemo.DAL
{
    //generieke interface<T> : Type
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        void Save();
    }
}
