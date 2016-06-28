using System.Collections.Generic;

namespace CarShowroom.Models.Dao
{
    public interface IDao<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        int Count();
    }
}