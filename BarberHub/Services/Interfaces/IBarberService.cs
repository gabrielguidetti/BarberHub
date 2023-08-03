using BarberHub.ViewModel;

namespace BarberHub.Services.Interfaces
{
    public interface IBarberService
    {
        BarberViewModel Add(BarberViewModel model);
        BarberViewModel Get(int id);
    }
}
