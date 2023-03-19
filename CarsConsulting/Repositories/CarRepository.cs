using CarsConsulting.DAL;
using CarsConsulting.DAL.Models;

namespace CarsConsulting.Repositories
{
    public class CarRepository : BaseRepository<Car, MainDbContext>, ICarRepository
    {
        public CarRepository(MainDbContext dbContext)
            :base(dbContext)
        { }
    }
}
