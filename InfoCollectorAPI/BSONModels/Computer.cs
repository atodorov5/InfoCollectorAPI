using InfoCollectorAPI.MongoDB;
using InfoCollectorAPI.MongoDB.Document;

namespace InfoCollectorAPI.BSONModels
{
    [BsonCollection("Computer")]
    public class Computer : Document
    {
        public string Hostname { get; set; }
        public string MACAddress { get; set; }
        public string MACAddressWiFi { get; set; }
        public DateTime LastMassage { get; set; }
        public DateTime LastChange { get; set; }

    }
}
