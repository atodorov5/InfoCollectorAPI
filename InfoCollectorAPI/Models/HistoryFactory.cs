using InfoCollectorAPI.BSONModels;

namespace InfoCollectorAPI.Models
{
    public static class HistoryFactory
    {
        public static HistoryView ToModel(this History history) =>
            history == null
                ? null
                : new HistoryView
                {
                    CreatedAt = history.CreatedAt,
                    History = new HistoryModel
                    {
                        OS = history.OS,
                        Manifacturer = history.Manifacturer,
                        Model = history.Model,
                        BIOSVersion = history.BIOSVersion,
                        LocalAdmins = history.LocalAdmins,
                        LocalUsers = history.LocalUsers,
                        StartupPrograms = history.StartupPrograms,
                    }
                    
                };
    }
}
