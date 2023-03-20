using CarsConsulting.DAL.Models;

namespace CarsConsulting.Services
{
    public interface IMakerService
    {
        public Task<Maker?> GetMakerByNameAsync(string name);
        public Task<Maker> CreateMakerAsync(string name);
    }
}
