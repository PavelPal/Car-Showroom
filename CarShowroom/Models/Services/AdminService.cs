using System.Collections.Generic;
using CarShowroom.Models.Dao;

namespace CarShowroom.Models.Services
{
    public class AdminService : IAdminService
    {
        public IEnumerable<T> GetAll<T>() where T : class
        {
            var unit = new UnitOfWork<T>();
            return unit.EntityDao.GetAll();
        }

        public T Get<T>(int id) where T : class
        {
            var unit = new UnitOfWork<T>();
            var item = unit.EntityDao.Get(id);
            return item;
        }

        public void Create<T>(T item) where T : class
        {
            var unit = new UnitOfWork<T>();
            unit.EntityDao.Create(item);
            unit.Save();
        }

        public void Update<T>(T item) where T : class
        {
            var unit = new UnitOfWork<T>();
            unit.EntityDao.Update(item);
            unit.Save();
        }

        public void Delete<T>(int id) where T : class
        {
            var unit = new UnitOfWork<T>();
            unit.EntityDao.Delete(id);
            unit.Save();
        }
    }
}