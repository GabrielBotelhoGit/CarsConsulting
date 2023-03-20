using CarsConsulting.DAL;
using CarsConsulting.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsConsulting.Repositories
{
    public class CarRepository : BaseRepository<Car, MainDbContext>, ICarRepository
    {
        public CarRepository(MainDbContext dbContext)
            :base(dbContext)
        { }

        public Task<List<Car>> GetAllWithMakerAsync()
        {
            return base._dbSet
                .Include(x => x.Maker)
                .ToListAsync();
        }
    }
}
