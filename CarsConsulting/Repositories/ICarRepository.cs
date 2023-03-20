using CarsConsulting.DAL.Models;

namespace CarsConsulting.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        public Task<List<Car>> GetAllWithMakerAsync();
    }
}
