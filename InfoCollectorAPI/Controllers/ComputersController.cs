using InfoCollectorAPI.BSONModels;
using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using Microsoft.AspNetCore.Mvc;

namespace InfoCollectorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputersController : ControllerBase
    {
        private readonly IMongoRepository<Computer> _computerRepository;

        public ComputersController(IMongoRepository<Computer> computerRepository)
        {
            _computerRepository = computerRepository;
        }

        [HttpGet(Name = "GetAllComputers")]
        public IEnumerable<ComputerModel> GetAllComputers()
        {
            var allComputers = _computerRepository.FilterBy(filter => true);

            var models = allComputers.Select(computer => new ComputerModel
            {
                Id = computer.Id.ToString(),
                Hostname = computer.Hostname,
                MACAddress = computer.MACAddress,
                MACAddressWiFi = computer.MACAddressWiFi,
                LastChange = computer.LastChange,
                LastMassage = computer.LastMassage,
            });

            return models;
        }
    }
}
