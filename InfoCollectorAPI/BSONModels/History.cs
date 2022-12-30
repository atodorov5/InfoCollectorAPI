using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using InfoCollectorAPI.MongoDB.Document;
using MongoDB.Bson;

namespace InfoCollectorAPI.BSONModels
{
    [BsonCollection("History")]
    public class History : Document
    {
        public string OS { get; set; }
        public string Manifacturer { get; set; }
        public string Model { get; set; }
        public string BIOSVersion { get; set; }
        public IEnumerable<LocalUser> LocalUsers { get; set; }
        public IEnumerable<string> LocalAdmins { get; set; }
        public IEnumerable<string> StartupPrograms { get; set; }
        public ObjectId ComputerId { get; set; }
    }
}
