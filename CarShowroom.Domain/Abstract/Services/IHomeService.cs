using CarShowroom.Domain.ViewModels;

namespace CarShowroom.Domain.Abstract.Services
{
    public interface IHomeService
    {
        IndexViewModel InicializeIndexViewModel();
    }
}