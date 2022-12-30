namespace InfoCollectorAPI.Models
{
    public class ComputerModel
    {
        public string Id { get; set; }
        public string Hostname { get; set; }
        public string MACAddress { get; set; }
        public string MACAddressWiFi { get; set; }
        public DateTime LastMassage { get; set; }
        public DateTime LastChange { get; set; }

    }
}
