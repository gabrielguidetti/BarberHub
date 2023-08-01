using BarberHub.Models;

namespace BarberHub.Repositories.Interfaces
{
    public interface IBarberShopRepository
    {
        BarberShop GetByUser(int userId);
        BarberShop Add(BarberShop model);
        BarberShop Update(BarberShop model);
    }
}
