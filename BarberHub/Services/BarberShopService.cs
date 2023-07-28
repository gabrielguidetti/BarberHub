using AutoMapper;
using BarberHub.Repositories.Interfaces;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;

namespace BarberHub.Services
{
    public class BarberShopService : IBarberShopService
    {
        private IBarberShopRepository BarberShopRepository { get; set; }
        private readonly IMapper _mapper;

        public BarberShopService(IBarberShopRepository barberShopRepository,
                                 IMapper mapper)
        {
            BarberShopRepository = barberShopRepository;
            _mapper = mapper;
        }

        public BarberShopViewModel GetByUser(int userId)
        {
            var result = BarberShopRepository.GetByUser(userId);

            if (result == null)
                return null;

            return _mapper.Map<BarberShopViewModel>(result);
        }
    }
}
