using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarShowroom.Domain.Abstract.Dao;

namespace CarShowroom.Domain.Concrete.Dao
{
    public class Dao<T> : IDao<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Dao(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _context.Set<T>().Find(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
            }
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }
    }
}