using CarsConsulting.Common.Exceptions;
using CarsConsulting.DAL.Models;
using CarsConsulting.Repositories;

namespace CarsConsulting.Services
{
    public class MakerService : IMakerService
    {
        private readonly IMakerRepository _makerRepository;

        public MakerService(IMakerRepository makerRepository)
        {
            _makerRepository = makerRepository;
        }        

        public async Task<Maker?> GetMakerByNameAsync(string name)
        {
            List<Maker> makers = await _makerRepository.GetAsync(x => x.Name == name).ConfigureAwait(false);
            return makers.FirstOrDefault();
        }

        public async Task<Maker> CreateMakerAsync(string name)
        {
            Maker maker = new(name);
            await _makerRepository.AddAsync(maker).ConfigureAwait(false);
            return maker;
        }
    }
}
