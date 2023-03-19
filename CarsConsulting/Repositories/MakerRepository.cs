using CarsConsulting.DAL;
using CarsConsulting.DAL.Models;

namespace CarsConsulting.Repositories
{
    public class MakerRepository : BaseRepository<Maker, MainDbContext>, IMakerRepository
    {
        public MakerRepository(MainDbContext dbContext)
            : base(dbContext) 
        { }
    }
}
