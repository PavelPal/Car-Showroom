using System;

namespace CarShowroom.Models.Dao
{
    public class UnitOfWork<T> : IDisposable where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext = new ApplicationDbContext();
        private bool _disposed;
        private Dao<T> _entityDao;
        public Dao<T> EntityDao => _entityDao ?? (_entityDao = new Dao<T>(_applicationDbContext));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _applicationDbContext.Dispose();
            }
            _disposed = true;
        }
    }
}