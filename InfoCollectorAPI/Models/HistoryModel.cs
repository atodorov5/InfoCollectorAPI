using InfoCollectorAPI.BSONModels;

namespace InfoCollectorAPI.Models
{
    public class HistoryModel
    {
        public string OS { get; set; }
        public string Manifacturer { get; set; }
        public string Model { get; set; }
        public string BIOSVersion { get; set; }
        public IEnumerable<LocalUser> LocalUsers { get; set; }
        public IEnumerable<string> LocalAdmins { get; set; }
        public IEnumerable<string> StartupPrograms { get; set; }
        
    }
}
