using CarsConsulting.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarsConsulting.AFunction
{
    public class CleanMaker
    {
        private readonly IMakerService _makerService;
        public CleanMaker(IMakerService makerService)
        {
            _makerService = makerService;
        }

        [Function("CleanMaker")]
        public async Task Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger logger)
        {
            //0 * * * * *
            //0 0 3 * * *
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var maker = await _makerService.GetMakerByNameAsync("Hyundai");
            Console.WriteLine(maker);
        }
    }
}
