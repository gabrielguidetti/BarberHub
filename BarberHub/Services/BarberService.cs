using AutoMapper;
using BarberHub.Models;
using BarberHub.Repositories.Interfaces;
using BarberHub.Services.Interfaces;
using BarberHub.ViewModel;

namespace BarberHub.Services
{
    public class BarberService : IBarberService
    {
        private IBarberRepository BarberRepository { get; set; }
        private readonly IMapper _mapper;

        public BarberService(IBarberRepository barberRepository,
                             IMapper mapper)
        {
            BarberRepository = barberRepository;
            _mapper = mapper;
        }

        public BarberViewModel Add(BarberViewModel model)
        {
            if (!IsValid(model))
                return null;

            var result = BarberRepository.Add(_mapper.Map<Barber>(model));

            return _mapper.Map<BarberViewModel>(result);
        }

        private bool IsValid(BarberViewModel model)
        {
            if(model.Name == null)
                return false;

            return true;
        }

        public BarberViewModel Get(int id)
        {
            var result = BarberRepository.Get(id);

            if (result == null)
                return null;

            return _mapper.Map<BarberViewModel>(result);
        }
    }
}
