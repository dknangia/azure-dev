namespace ContactManager.V1.Settings
{
    public interface ISettings
    {
        Dictionary<string, string> GetSettings();
        string SetSettings(Dictionary<string, string> settingsDictionary);
    }

    public class GlobalSettings : ISettings
    {
        public Dictionary<string, string> GetSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("Theme", "Theme");
            return settings;
        }

        public string SetSettings(Dictionary<string, string> settingsDictionary)
        {
            foreach (var item in settingsDictionary)
            {
                // Save to the DB
            }

            return $"Settings has been saved in the DB";
        }
    }
}
