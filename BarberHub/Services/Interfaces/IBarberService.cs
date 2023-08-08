using BarberHub.ViewModel;

namespace BarberHub.Services.Interfaces
{
    public interface IBarberService
    {
        BarberViewModel Add(BarberViewModel model);
        BarberViewModel Update(BarberViewModel model);
        BarberViewModel Get(int id);
    }
}
