using InfoCollectorAPI.MongoDB;
using InfoCollectorAPI.MongoDB.Document;

namespace InfoCollectorAPI.Models
{
    [BsonCollection("Users")]
    public class User : Document
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
