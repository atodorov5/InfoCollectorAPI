using InfoCollectorAPI.BSONModels;
using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace InfoCollectorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMongoRepository<History> _historyRepository;

        public HistoryController(IMongoRepository<History> historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpGet(Name = "GetCurrentAndLastHistory")]
        public IEnumerable<HistoryView> GetCurrentAndLastHistory(string id)
        {
            ObjectId computerId = ObjectId.Parse(id);

            var allHistory = _historyRepository.FilterBy(filter => filter.ComputerId == computerId).OrderByDescending(x => x.CreatedAt);
            var historyList = new List<HistoryView>
            {
                allHistory.First().ToModel(),
                allHistory.ToList().ElementAt(1).ToModel(),
            };

            return historyList;
        }
    }
}
