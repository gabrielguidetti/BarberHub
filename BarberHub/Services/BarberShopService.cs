using AutoMapper;
using BarberHub.Models;
using BarberHub.Repositories.Interfaces;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;
using System.Security.Claims;

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

        public BarberShopViewModel Add(BarberShopViewModel model)
        {
            if(!Validate(model))
                return null;

            var result = BarberShopRepository.Add(_mapper.Map<BarberShop>(model));

            return _mapper.Map<BarberShopViewModel>(result);
        }

        public BarberShopViewModel Update(BarberShopViewModel model)
        {
            if (!Validate(model))
                return null;

            var result = BarberShopRepository.Update(_mapper.Map<BarberShop>(model));

            return _mapper.Map<BarberShopViewModel>(result);
        }

        private bool Validate(BarberShopViewModel model)
        {
            if (model.Name == null || model.Address == null)
                return false;

            return true;
        }
    }
}
