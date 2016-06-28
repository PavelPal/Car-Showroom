using System.Collections.Generic;

namespace CarShowroom.Models.Services
{
    public interface IAdminService
    {
        IEnumerable<T> GetAll<T>() where T : class;
        T Get<T>(int id) where T : class;
        void Create<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void Delete<T>(int id) where T : class;
    }
}